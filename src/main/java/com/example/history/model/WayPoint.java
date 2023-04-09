package com.example.history.model;

import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.UUID;

// WayPoint model
@Data
@AllArgsConstructor
public class WayPoint {
    private String title;
    private WayPointKind kind;
    private UUID roadmap_id;
}