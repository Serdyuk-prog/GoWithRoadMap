package history.controllers;

import history.services.HistoryService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api")
public class HistoryController {
    private final HistoryService historyService;

    public HistoryController(HistoryService historyService) {
        this.historyService = historyService;
    }

    public ResponseEntity getUserHistory(@RequestParam(name = "briefly", required = false) boolean briefly) {
        return historyService.getUserHistory(briefly);
    }
}
