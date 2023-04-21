package com.example.history.model;

import jakarta.persistence.*;

// WayPoint model
@Entity
@Table(name = "waypoint")
public class WayPoint {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private long id;

    @Column(name = "title", nullable = false)
    private String title;

    @Enumerated(EnumType.STRING)
    @Column(name = "kind", nullable = false)
    private WayPointKind kind;

    @Column(name = "roadmap_id")
    private long roadmapId;

    public WayPoint() {
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
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

    public long getRoadmapId() {
        return roadmapId;
    }

    public void setRoadmapId(long roadmapId) {
        this.roadmapId = roadmapId;
    }
}