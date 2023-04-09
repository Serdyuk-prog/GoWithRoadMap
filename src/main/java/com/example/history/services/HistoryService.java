package com.example.history.services;

import com.example.history.model.History;
import com.example.history.model.WayPoint;
import com.example.history.model.WayPointKind;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.UUID;

// History service class
@Service
public class HistoryService {

    // Get user history method
    public History getUserHistory(boolean briefly) throws Exception {

        // TODO: Implement the logic to fetch the user history from the database or other sources

        // For example, return a dummy history object
        History history = new History(List.of(
                new WayPoint("HTTPS", WayPointKind.LeafCompleted, UUID.randomUUID()),
                new WayPoint("Web Development", WayPointKind.NodeCompleted, UUID.randomUUID()),
                new WayPoint("Full Stack Developer", WayPointKind.RoadmapCompleted, UUID.randomUUID()),
                new WayPoint("ABAB", WayPointKind.LeafCompleted, UUID.randomUUID())
        ));

        // If briefly is true, only return the last waypoint
        if (briefly) {
            history.setWaypoints(List.of(history.getWaypoints().get(history.getWaypoints().size() - 1)));
        }

        // If the user id is not found, throw an exception with an error message
//        if (history == null) {
//            throw new Exception(new Error("User not found"));
//        }

        return history;
    }
}