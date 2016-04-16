import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import java.util.*;

public class EstrategiaAntiNoturnosTest {
    @Test
    public void ataqueCom3Noturnos1Verde2Dwarves() throws NaoPodeAlistarException {
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        Elfo elfoNoturno1 = new ElfoNoturno("EN1");
        Elfo elfoNoturno2 = new ElfoNoturno("EN2");
        Elfo elfoNoturno3 = new ElfoNoturno("EN3");
        Elfo elfoVerde1 = new ElfoVerde("EV1");
        exercito.alistar(elfoNoturno1);
        exercito.alistar(elfoNoturno2);
        exercito.alistar(elfoNoturno3);
        exercito.alistar(elfoVerde1);
        ArrayList<Dwarf> dwarves = new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2")));
        exercito.atacar(dwarves);
        List<Elfo> ordemAtaque = exercito.getOrdemDoUltimoAtaque();
        assertEquals(elfoVerde1, ordemAtaque.get(0));
        assertEquals(elfoVerde1, ordemAtaque.get(1));
        // para o hashmap deste exército, EN2 virá antes, depois EN1 e EN3.
        assertEquals(elfoNoturno2, ordemAtaque.get(2));
        assertEquals(elfoNoturno2, ordemAtaque.get(3));
    }

    @Test
    public void ataqueCom3Noturnos4Dwarves() throws NaoPodeAlistarException {
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        Elfo elfoNoturno1 = new ElfoNoturno("EN1");
        Elfo elfoNoturno2 = new ElfoNoturno("EN2");
        Elfo elfoNoturno3 = new ElfoNoturno("EN3");
        exercito.alistar(elfoNoturno1);
        exercito.alistar(elfoNoturno2);
        exercito.alistar(elfoNoturno3);
        ArrayList<Dwarf> dwarves = new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"), new Dwarf("D3"), new Dwarf("D4")));
        exercito.atacar(dwarves);
        List<Elfo> ordemAtaque = exercito.getOrdemDoUltimoAtaque();
        // para o hashmap deste exército, EN2 virá antes, depois EN1 e EN3.
        assertEquals(elfoNoturno2, ordemAtaque.get(0));
        assertEquals(elfoNoturno2, ordemAtaque.get(1));
        assertEquals(elfoNoturno2, ordemAtaque.get(2));
    }

    @Test
    public void ataqueCom3VerdesApenas() throws NaoPodeAlistarException {
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        Elfo elfoVerde1 = new ElfoVerde("EV1");
        Elfo elfoVerde2 = new ElfoVerde("EV2");
        Elfo elfoVerde3 = new ElfoVerde("EV3");
        exercito.alistar(elfoVerde1);
        exercito.alistar(elfoVerde2);
        exercito.alistar(elfoVerde3);
        ArrayList<Dwarf> dwarves = new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2")));
        exercito.atacar(dwarves);
        List<Elfo> ordemAtaque = exercito.getOrdemDoUltimoAtaque();
        // para o hashmap deste exército, EV2 virá antes, depois EV1 e EV3.
        assertEquals(elfoVerde2, ordemAtaque.get(0));
        assertEquals(elfoVerde2, ordemAtaque.get(1));
        assertEquals(elfoVerde1, ordemAtaque.get(2));
        assertEquals(elfoVerde1, ordemAtaque.get(3));
        assertEquals(elfoVerde3, ordemAtaque.get(4));
        assertEquals(elfoVerde3, ordemAtaque.get(5));
    }
    
    @Test
    public void ataqueComExercitoVazio() throws NaoPodeAlistarException {
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        ArrayList<Dwarf> dwarves = new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2")));
        exercito.atacar(dwarves);
        List<Elfo> ordemAtaque = exercito.getOrdemDoUltimoAtaque();
        assertTrue(ordemAtaque.isEmpty());
    }
}
