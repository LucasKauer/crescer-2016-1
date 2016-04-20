import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import java.util.*;

public class EstrategiaPriorizandoElfosVerdesTest {

    @After
    public void tearDown() {
        System.gc();
    }

    @Test
    public void exercitoEmbaralhadoPriorizaAtaqueComElfosVerdes() throws NaoPodeAlistarException {
        // Arrange
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.mudarEstrategia(new EstrategiaPriorizandoElfosVerdes());
        Elfo en1 = new ElfoNoturno("Night 1");
        Elfo en2 = new ElfoNoturno("Night 2");
        Elfo ev1 = new ElfoVerde("Green 1");
        Elfo en3 = new ElfoNoturno("Night 3");
        Elfo ev2 = new ElfoVerde("Green 2");
        exercito.alistar(en1);
        exercito.alistar(en2);
        exercito.alistar(ev1);
        exercito.alistar(en3);
        exercito.alistar(ev2);
        ArrayList<Elfo> esperado = new ArrayList<>(Arrays.asList(ev2, ev1, en3, en2, en1));
        // Act
        exercito.atacar(new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"), new Dwarf("D3"))));
        // Assert
        assertEquals(esperado, exercito.getOrdemDoUltimoAtaque());
    }

    @Test
    public void exercitoSóDeVerdes() throws NaoPodeAlistarException {
        // Arrange
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.mudarEstrategia(new EstrategiaPriorizandoElfosVerdes());
        Elfo ev1 = new ElfoVerde("Green 1");
        Elfo ev2 = new ElfoVerde("Green 2");
        exercito.alistar(ev1);
        exercito.alistar(ev2);
        ArrayList<Elfo> esperado = new ArrayList<>(Arrays.asList(ev2, ev1));
        // Act
        exercito.atacar(new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"), new Dwarf("D3"))));
        // Assert
        assertEquals(esperado, exercito.getOrdemDoUltimoAtaque());
    }

    @Test
    public void exercitoSóDeNoturnos() throws NaoPodeAlistarException {
        // Arrange
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.mudarEstrategia(new EstrategiaPriorizandoElfosVerdes());
        Elfo en1 = new ElfoNoturno("EN1");
        Elfo en2 = new ElfoNoturno("EN2");
        exercito.alistar(en1);
        exercito.alistar(en2);
        ArrayList<Elfo> esperado = new ArrayList<>(Arrays.asList(en2, en1));
        // Act
        exercito.atacar(new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"), new Dwarf("D3"))));
        // Assert
        assertEquals(esperado, exercito.getOrdemDoUltimoAtaque());
    }

    @Test
    public void ataqueComExercitoVazio() throws NaoPodeAlistarException {
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.mudarEstrategia(new EstrategiaPriorizandoElfosVerdes());
        exercito.atacar(new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"))));
        List<Elfo> ordemAtaque = exercito.getOrdemDoUltimoAtaque();
        assertTrue(ordemAtaque.isEmpty());
    }

    @Test
    public void ataqueComVerdesENoturnoMorto() throws NaoPodeAlistarException {
        // Arrange
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.mudarEstrategia(new EstrategiaPriorizandoElfosVerdes());
        Elfo en1 = new ElfoNoturno("Night 1");
        Elfo en2 = new ElfoNoturno("Night 2");
        Elfo ev1 = new ElfoVerde("Green 1");
        Elfo en3 = new ElfoNoturno("Night 3");
        Elfo ev2 = new ElfoVerde("Green 2");
        for (int i = 0; i < 90; i++) en1.atirarFlecha(new Dwarf("D1"));
        exercito.alistar(en1);
        exercito.alistar(en2);
        exercito.alistar(ev1);
        exercito.alistar(en3);
        exercito.alistar(ev2);
        ArrayList<Elfo> esperado = new ArrayList<>(Arrays.asList(ev2, ev1, en3, en2));
        // Act
        exercito.atacar(new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"), new Dwarf("D3"))));
        // Assert
        assertEquals(esperado, exercito.getOrdemDoUltimoAtaque());
    }
}
