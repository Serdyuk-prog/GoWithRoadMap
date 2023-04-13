package history.services;

import history.model.History;
import history.model.WayPoint;
import history.model.WayPointKind;
import history.repositories.WayPointRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.UUID;

@Service
@RequiredArgsConstructor
public class HistoryService {
    @Autowired
    private final WayPointRepository waypointRepository;

    public ResponseEntity getUserHistory(boolean briefly) {
        try {

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
//            History history = new History(wayPointRepository.findAll());

            if (briefly) {
                history.setWaypoints(List.of(history.getWaypoints().get(history.getWaypoints().size() - 1)));
            }

            return new ResponseEntity<>(history, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(new Error(e.getMessage()), HttpStatus.NOT_FOUND);
        }
    }
}
