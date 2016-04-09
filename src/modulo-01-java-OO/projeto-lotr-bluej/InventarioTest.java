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

    @Test
    public void ordenarItensBaguncados() {
        // Arrange
        Inventario mochila = new Inventario();
        Item elderScroll = new Item(9, "Elder Scroll");
        Item escudo = new Item(99, "Escudo");
        Item canivete = new Item(2, "Canivete suíço");
        mochila.adicionarItem(elderScroll);
        mochila.adicionarItem(escudo);
        mochila.adicionarItem(canivete);
        // Act
        mochila.ordenarItens();
        // Assert
        assertEquals(canivete, mochila.getItens().get(0));
        assertEquals(elderScroll, mochila.getItens().get(1));
        assertEquals(escudo, mochila.getItens().get(2));
    }
    
    @Test
    public void ordenarItensComMesmaQuantidade() {
        // Arrange
        Inventario mochila = new Inventario();
        Item elderScroll = new Item(9, "Elder Scroll");
        Item escudo = new Item(9, "Escudo");
        Item canivete = new Item(9, "Canivete suíço");
        mochila.adicionarItem(elderScroll);
        mochila.adicionarItem(escudo);
        mochila.adicionarItem(canivete);
        // Act
        mochila.ordenarItens();
        // Assert
        assertEquals(elderScroll, mochila.getItens().get(0));
        assertEquals(escudo, mochila.getItens().get(1));
        assertEquals(canivete, mochila.getItens().get(2));
    }
    
    @Test
    public void ordenarItensVazio() {
        // Arrange
        Inventario mochila = new Inventario();
        // Act
        mochila.ordenarItens();
        // Assert
        assertEquals(0, mochila.getItens().size());
    }
}


