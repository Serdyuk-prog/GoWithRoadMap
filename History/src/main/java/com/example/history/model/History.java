package com.example.history.model;// History service
// Service that serves history
// Version: 0.1.0

import com.example.history.model.WayPoint;
import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.List;

// History model
@Data
@AllArgsConstructor
public class History {
    private List<WayPoint> waypoints;
}