import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class ElfoVerdeTest
{
    @Test
    public void elfoVerdeAtacaUmDwarf() {
        ElfoVerde green = new ElfoVerde("Fandango");
        green.atirarFlecha(new Dwarf("John Doe"));

        assertEquals(2, green.getExperiencia());
    }

    @Test
    public void elfoVerdeAtacaUmDwarfEIrishDwarf() {
        ElfoVerde green = new ElfoVerde("Green Elf");
        Dwarf common = new Dwarf("Common Dwarf");
        IrishDwarf irish = new IrishDwarf("John 'O Doe");
        green.atirarFlecha(irish);
        green.atirarFlecha(common);
        assertEquals(4, green.getExperiencia());
    }

    @Test
    public void elfoVerdeAdicionaEspadaValiriana() {
        ElfoVerde sortudo = new ElfoVerde("Sortudo");
        Item espada = new Item(1, "Espada de aço valiriano");
        sortudo.adicionarItem(espada);
        assertEquals(1, sortudo.getInventario().getItens().size());
        assertEquals(espada, sortudo.getInventario().getItens().get(0));
    }

    @Test
    public void elfoVerdeAdicionaItemComDescricaoInvalida() {
        ElfoVerde sortudo = new ElfoVerde("Mugless");
        sortudo.adicionarItem(new Item(1, "Caneca"));
        assertEquals(0, sortudo.getInventario().getItens().size());
    }

    @Test
    public void elfoVerdeAdicionaArcoEFlechaVidroENulo() {
        ElfoVerde sortudo = new ElfoVerde("Celeborn");
        Item arcoEFlecha = new Item(1, "Arco e Flecha de Vidro");
        sortudo.adicionarItem(arcoEFlecha);
        sortudo.adicionarItem(null);
        assertEquals(1, sortudo.getInventario().getItens().size());
        assertEquals(arcoEFlecha, sortudo.getInventario().getItens().get(0));
    }

    @Test
    public void elfoVerdeAdicionaArcoEFlechaVidroEDescricaoNula() {
        ElfoVerde sortudo = new ElfoVerde("Celeborn");
        Item arcoEFlecha = new Item(1, "Arco e Flecha de Vidro");
        Item descricaoNula = new Item(1, null);
        sortudo.adicionarItem(arcoEFlecha);
        sortudo.adicionarItem(descricaoNula);
        assertEquals(1, sortudo.getInventario().getItens().size());
        assertEquals(arcoEFlecha, sortudo.getInventario().getItens().get(0));
    }    
}
