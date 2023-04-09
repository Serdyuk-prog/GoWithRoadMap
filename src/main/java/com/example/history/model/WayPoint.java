package com.example.history.model;

import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;

// WayPoint model
@Entity
@Data
@AllArgsConstructor
@NoArgsConstructor
public class WayPoint {
    @Id
    private UUID id;
    private String title;
    private WayPointKind kind;
    private UUID roadmap_id;
}