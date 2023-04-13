package history.model;

import lombok.Getter;
import lombok.Setter;

import javax.persistence.*;
import java.util.UUID;

@Entity
@Getter
@Setter
@Table(name = "`waypoint`")
public class WayPoint {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(columnDefinition = "uuid")
    private UUID id;
    @Column(columnDefinition = "VARCHAR(255)", nullable = false)
    private String title;
    @Column(columnDefinition = "ENUM('LeafCompleted`, `NodeCompleted`, 'RoadmapCompleted')", nullable = false)
    private WayPointKind kind;
    @Column(name = "roadmap_id", columnDefinition = "VARCHAR(255)")
    private UUID roadmapId;
}
