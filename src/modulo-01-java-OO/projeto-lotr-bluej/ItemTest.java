import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class ItemTest {
    
    @Test
    public void aumentar1000UnidadesDeZero() {
        Item item = new Item(0, "Elder Scroll");
        item.aumentar1000Unidades();
        assertEquals(1000, item.getQuantidade());
    }
    
    @Test
    public void aumentar1000UnidadesDeUm() {
        Item item = new Item(1, "Elder Scroll");
        item.aumentar1000Unidades();
        assertEquals(1001, item.getQuantidade());
    }
    
    @Test
    public void aumentar1000UnidadesDeMil() {
        Item item = new Item(1000, "Elder Scroll");
        item.aumentar1000Unidades();
        assertEquals(2000, item.getQuantidade());
    }
}
