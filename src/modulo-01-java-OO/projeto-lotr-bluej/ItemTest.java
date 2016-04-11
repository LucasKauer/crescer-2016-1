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
    
    @Test
    public void aumentarProporcionalQuantidade3() {
        Item item = new Item(3, "Chapéu");
        item.aumentarProporcionalQuantidade();
        assertEquals(6003, item.getQuantidade());
    }
    
    @Test
    public void aumentarProporcionalQuantidade1() {
        Item item = new Item(1, "Elder Scroll");
        item.aumentarProporcionalQuantidade();
        assertEquals(1001, item.getQuantidade());
    }
    
    @Test
    public void aumentarProporcionalQuantidade0() {
        Item item = new Item(0, "Elder Scroll");
        item.aumentarProporcionalQuantidade();
        assertEquals(0, item.getQuantidade());
    }
    
    @Test
    public void aumentarProporcionalQuantidade20() {
        Item item = new Item(20, "Semente dos Deuses");
        item.aumentarProporcionalQuantidade();
        assertEquals(210020, item.getQuantidade());
    }
}
