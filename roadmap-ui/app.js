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

app.get("/history", (req, res) => {
    res.render("history", { waypoints });
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
    // res.send(req.body);
    res.redirect("/" + req.params.id);
});

app.listen(3000, () => {
    console.log("Listening оn port 3000");
});

const maps = [
    {
        id: "1fa85f64-5717-4562-b3fc-2c963f66afa6",
        title: "Map1",
        description: "string",
        content: [
            {
                id: "2fa85f64-5717-4562-b3fc-2c963f66afa6",
                title: "step1",
                description: "string",
                kind: "optional",
                status: "proposed",
            },
            {
                id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                title: "step1",
                description: "string",
                kind: "optional",
                status: "proposed",
            },
        ],
    },
    {
        id: "4fa85f64-5717-4562-b3fc-2c963f66afa6",
        title: "Map2",
        description: "string",
        content: [
            {
                id: "5fa85f64-5717-4562-b3fc-2c963f66afa6",
                title: "step1",
                description: "string",
                kind: "optional",
                status: "proposed",
            },
        ],
    },
];

const waypoints = [
    {
        title: "HTTPS",
        kind: "LeafCompleted",
        roadmap_id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    },
    {
        title: "HTML",
        kind: "NodeCompleted",
        roadmap_id: "2fa85f64-5717-4562-b3fc-2c963f66afa6",
    },
];
