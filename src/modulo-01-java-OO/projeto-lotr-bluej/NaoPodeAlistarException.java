public class NaoPodeAlistarException extends Exception {
    public NaoPodeAlistarException() {
        this("Elfos do tipo normal não podem ser alistado!");
    }
    
    public NaoPodeAlistarException(String message) {
        super(message);
    }
}
