import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class SindarinParaInglesTest {
    @Test
    public void traduzirNaurParaIngles() {
        // naur
        TradutorSindarin tradutorIngles = new SindarinParaIngles();
        assertEquals("fire", tradutorIngles.traduzir("naur"));
    }
    
    @Test
    public void traduzirNullParaIngles() {
        // naur
        TradutorSindarin tradutorIngles = new SindarinParaIngles();
        assertNull(tradutorIngles.traduzir("null"));
    }
}










