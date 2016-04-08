import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class InventarioTest {
    @Test
    public void getDescricoesItensVazio() {
        Inventario inventario = new Inventario();
        String obtido = inventario.getDescricoesItens();
        assertEquals("", obtido);
    }

    @Test
    public void getDescricoesComUmItem() {
        Inventario inventario = new Inventario();
        inventario.adicionarItem(new Item(1, "Espada"));
        String obtido = inventario.getDescricoesItens();
        assertEquals("Espada", obtido);
    }

    @Test
    public void getDescricoesComDoisItens() {
        Inventario inventario = new Inventario();
        inventario.adicionarItem(new Item(1, "Espada"));
        inventario.adicionarItem(new Item(1, "Escudo"));
        String obtido = inventario.getDescricoesItens();
        assertEquals("Espada,Escudo", obtido);
    }
    
    @Test
    public void aumentar1000UnidadesComInventarioVazio() {
        Inventario inventario = new Inventario();
        inventario.aumentar1000UnidadesPorItem();
        assertTrue(inventario.getItens().isEmpty());
    }
    
    @Test
    public void aumentar1000UnidadesComApenasUmItem() {
        Inventario inventario = new Inventario();
        inventario.adicionarItem(new Item(1, "Espada"));
        inventario.aumentar1000UnidadesPorItem();
        assertEquals(1001, inventario.getItens().get(0).getQuantidade());
    }
    
    @Test
    public void aumentar1000UnidadesComApenasDoisItens() {
        Inventario inventario = new Inventario();
        inventario.adicionarItem(new Item(1, "Espada Z"));
        inventario.adicionarItem(new Item(1, "Nuvem voadora"));
        inventario.aumentar1000UnidadesPorItem();
        assertEquals(1001, inventario.getItens().get(0).getQuantidade());
        assertEquals(1001, inventario.getItens().get(1).getQuantidade());
    }
    
    @Test
    public void getItemComMaiorQuantidadeComInventarioVazio() {
        Inventario inventario = new Inventario();
        assertNull(inventario.getItemComMaiorQuantidade());
    }
    
    @Test
    public void getItemComMaiorQuantidadeComApenasUmItem() {
        Inventario inventario = new Inventario();
        inventario.adicionarItem(new Item(2, "Semente dos Deuses"));
        assertEquals(2, inventario.getItemComMaiorQuantidade().getQuantidade());
    }
    
    @Test
    public void getItemComMaiorQuantidadeComTresItens() {
        Inventario inventario = new Inventario();
        inventario.adicionarItem(new Item(15, "Flechas de gelo"));
        inventario.adicionarItem(new Item(20, "Lembas"));
        inventario.adicionarItem(new Item(2, "Semente dos Deuses"));
        assertEquals(20, inventario.getItemComMaiorQuantidade().getQuantidade());
    }
}











