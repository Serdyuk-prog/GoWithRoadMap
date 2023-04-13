package history.repositories;

import history.model.WayPoint;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.UUID;

@Repository
public interface WayPointRepository extends JpaRepository<WayPoint, UUID> {
}
