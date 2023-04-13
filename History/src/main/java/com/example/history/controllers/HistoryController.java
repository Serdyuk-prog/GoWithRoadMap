package com.example.history.controllers;

import com.example.history.dto.error.Error;
import com.example.history.model.History;
import com.example.history.services.HistoryService;
import com.example.history.rabbitmq.RabbitMQSender;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@CrossOrigin(origins = "*", maxAge = 3600, allowedHeaders = "*")
@RestController
@RequestMapping("/api")
public class HistoryController {

    // History service instance
    private final HistoryService historyService;

    @Autowired
    private RabbitMQSender rabbitMQSender;

    public HistoryController(HistoryService historyService) {
        this.historyService = historyService;
    }

    // Get user history endpoint
    @GetMapping("/history/byUser")
    public ResponseEntity getUserHistory(@RequestParam(name = "briefly", required = false, defaultValue = "true") String briefly) {

        Boolean brif = briefly.equals("true");
        try {
            // Call the history service method
            History history = historyService.getUserHistory(brif);

//            history.getWaypoints().forEach(w -> {
//                rabbitMQSender.sendWayPoint(w);
//            });

            // Return the history object with status code 200
            return new ResponseEntity<>(history, HttpStatus.OK);

        } catch (Exception e) {
            // If an exception occurs, return the error object with status code 404
            return new ResponseEntity<>(new Error(e.getMessage()), HttpStatus.NOT_FOUND);
        }
    }
}
