package history.model;

import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.List;

@Data
@AllArgsConstructor
public class History {
    private List<WayPoint> waypoints;
}
