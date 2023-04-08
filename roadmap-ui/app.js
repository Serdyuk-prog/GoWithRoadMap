const express = require("express");
const path = require("path");
const ejsMate = require("ejs-mate");
const methodOverride = require("method-override");
const { log } = require("console");

const app = express();

app.set("view engine", "ejs");
app.set("views", path.join(__dirname, "views"));
app.engine("ejs", ejsMate);
app.use(express.urlencoded({ extended: true }));
app.use(methodOverride("_method"));

app.get("/", (req, res) => {
    // get all maps
    res.render("main", { maps });
});

app.get("/new", (req, res) => {
    res.render("newMap");
});

app.get("/edit/:id", (req, res) => {
    // get map by id
    let map = {};
    for (let el of maps) {
        if (el.id == req.params.id) {
            map = el;
        }
    }
    res.render("editMap", { map });
});

app.get("/:id", (req, res) => {
    // get map by id
    let map = {};
    for (let el of maps) {
        if (el.id == req.params.id) {
            map = el;
        }
    }
    res.render("map", { map });
});

app.post("/map", (req, res) => {
    console.log(req.body);
    // send new map request
    res.redirect("/");
});

app.post("/map/:id", (req, res) => {
    console.log(req.body);
    // send edit map request
    res.redirect("/" + req.params.id);
});

app.listen(3000, () => {
    console.log("Listening оn port 3000");
});

const maps = [
    {
        id: "1",
        title: "Name1",
        author_id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        description: "string",
        root: [
            {
                id: "1",
                parent_id: null,
                title: "Entry level",
                description: "Do some easy steps",
                kind: "required",
                status: "proposed",
                children: [
                    {
                        id: "11",
                        parent_id: null,
                        title: "Entry level",
                        description: "Do some easy steps",
                        kind: "required",
                        status: "proposed",
                        children: [
                            {
                                id: "111",
                                parent_id: null,
                                title: "Entry level",
                                description: "Do some easy steps",
                                kind: "required",
                                status: "proposed",
                                children: [],
                            },
                        ],
                    },
                    {
                        id: "12",
                        parent_id: null,
                        title: "Entry level",
                        description: "Do some easy steps",
                        kind: "required",
                        status: "proposed",
                        children: [],
                    },
                ],
            },
        ],
    },
    {
        id: "2",
        title: "Name2",
        author_id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        description: "string",
        root: [
            {
                id: "1",
                parent_id: null,
                title: "Entry level",
                description: "Do some easy steps",
                kind: "required",
                status: "proposed",
                children: [],
            },
        ],
    },
    {
        id: "3",
        title: "Name3",
        author_id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        description: "string",
        root: [
            {
                id: "1",
                parent_id: null,
                title: "Entry level",
                description: "Do some easy steps",
                kind: "required",
                status: "proposed",
                children: [],
            },
        ],
    },
];
