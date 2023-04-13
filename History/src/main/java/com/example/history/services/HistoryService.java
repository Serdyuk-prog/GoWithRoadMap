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

    private final WayPointRepository wayPointRepository;

    @Autowired
    public HistoryService(WayPointRepository wayPointRepository) {
        this.wayPointRepository = wayPointRepository;
    }

    // Get user history method
    public History getUserHistory(boolean briefly) {

        // For example, return a dummy history object

        WayPoint wp1 = new WayPoint();
        wp1.setId(UUID.randomUUID());
        wp1.setTitle("HTTPS");
        wp1.setKind(WayPointKind.LeafCompleted);
        wp1.setRoadmapId(UUID.randomUUID());

        WayPoint wp2 = new WayPoint();
        wp2.setId(UUID.randomUUID());
        wp2.setTitle("Full Stack Developer");
        wp2.setKind(WayPointKind.NodeCompleted);
        wp2.setRoadmapId(UUID.randomUUID());

        History history = new History(List.of(wp1, wp2));

        // History history = new History(wayPointRepository.findAll());

        // If briefly is true, only return the last waypoint
        if (briefly) {
            history.setWaypoints(List.of(history.getWaypoints().get(history.getWaypoints().size() - 1)));
        }

        return history;
    }
}