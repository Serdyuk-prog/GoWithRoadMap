package com.example.history.services;

import com.example.history.model.History;
import com.example.history.model.WayPoint;
import com.example.history.model.WayPointKind;
import com.example.history.repositories.WayPointRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.UUID;

// History service class
@Service
public class HistoryService {
    @Autowired
    private WayPointRepository wayPointRepository;

    // Get user history method
    public History getUserHistory(boolean briefly) {

        // For example, return a dummy history object
        History history = new History(List.of(
                new WayPoint(UUID.randomUUID(), "HTTPS", WayPointKind.LeafCompleted, UUID.randomUUID()),
                new WayPoint(UUID.randomUUID(), "Web Development", WayPointKind.NodeCompleted, UUID.randomUUID()),
                new WayPoint(UUID.randomUUID(), "Full Stack Developer", WayPointKind.RoadmapCompleted, UUID.randomUUID()),
                new WayPoint(UUID.randomUUID(), "ABAB", WayPointKind.LeafCompleted, UUID.randomUUID())
        ));

        //TODO: Test with database running.
//        History history = new History(wayPointRepository.findAll());

        // If briefly is true, only return the last waypoint
        if (briefly) {
            history.setWaypoints(List.of(history.getWaypoints().get(history.getWaypoints().size() - 1)));
        }

        return history;
    }
}