package com.example.history.repositories;

import com.example.history.model.WayPoint;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface WayPointRepository extends JpaRepository<WayPoint, Long> {
}
