package history.dto.error;

public class Error {
    private String message;

    // Constructor
    public Error(String message) {
        this.message = message;
    }

    // Getter and setter
    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }
}
