package com.example.history.model;

import jakarta.persistence.*;

import java.util.UUID;

// WayPoint model
@Entity
@Table(name = "waypoint")
public class WayPoint {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", columnDefinition = "uuid")
    private UUID id;

    @Column(name = "title", nullable = false)
    private String title;

    @Column(name = "kind", nullable = false)
    private WayPointKind kind;

    @Column(name = "roadmap_id")
    private UUID roadmapId;

    public WayPoint() {
    }

    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public WayPointKind getKind() {
        return kind;
    }

    public void setKind(WayPointKind kind) {
        this.kind = kind;
    }

    public UUID getRoadmapId() {
        return roadmapId;
    }

    public void setRoadmapId(UUID roadmapId) {
        this.roadmapId = roadmapId;
    }
}