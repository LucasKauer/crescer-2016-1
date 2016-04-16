import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import java.util.*;

public class EstrategiaIntercaladaTest {
    @Test
    public void exercitoIntercaladoComeçandoComElfoNoturno() throws NaoPodeAlistarException {
        // Arrange
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.mudarEstrategia(new EstrategiaIntercalada());
        Elfo night1 = new ElfoNoturno("Night 1");
        Elfo night2 = new ElfoNoturno("Night 2");
        Elfo green1 = new ElfoVerde("Green 1");
        Elfo night3 = new ElfoNoturno("Night 3");
        Elfo green2 = new ElfoVerde("Green 2");
        Elfo green3 = new ElfoVerde("Green 3");
        exercito.alistar(night1);
        exercito.alistar(night2);
        exercito.alistar(green1);
        exercito.alistar(night3);
        exercito.alistar(green2);
        exercito.alistar(green3);
        List<Elfo> esperado = new ArrayList<>(Arrays.asList(night3, green2, night1, green1, night2, green3));
        // Act
        exercito.atacar(new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"), new Dwarf("D3"))));
        // Assert
        ArrayList<Elfo> resultado = exercito.getOrdemDoUltimoAtaque();
        assertEquals(esperado, resultado);
    }

    @Test
    public void exercitoIntercaladoComeçandoComElfoVerde() throws NaoPodeAlistarException {
        // Arrange
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.mudarEstrategia(new EstrategiaIntercalada());
        Elfo night1 = new ElfoNoturno("EN1");
        Elfo night2 = new ElfoNoturno("EN2");
        Elfo green1 = new ElfoVerde("EV1");
        Elfo green2 = new ElfoVerde("EV2");
        exercito.alistar(night1);
        exercito.alistar(night2);
        exercito.alistar(green1);
        exercito.alistar(green2);
        List<Elfo> esperado = new ArrayList<>(Arrays.asList(green2, night2, green1, night1));
        // Act
        exercito.atacar(new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"), new Dwarf("D3"))));
        // Assert
        ArrayList<Elfo> resultado = exercito.getOrdemDoUltimoAtaque();
        assertEquals(esperado, resultado);
    }

    @Test
    public void exercitoDesproporcionalNãoAtaca() throws NaoPodeAlistarException {
        // Arrange
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.mudarEstrategia(new EstrategiaIntercalada());
        Elfo night1 = new ElfoNoturno("Noturno 1");
        Elfo night2 = new ElfoNoturno("Elfo Noturno 2");
        Elfo green1 = new ElfoVerde("Elfo Verde 1");
        exercito.alistar(green1);
        exercito.alistar(night1);
        exercito.alistar(night2);
        // Act
        exercito.atacar(new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"), new Dwarf("D3"))));
        // Assert
        ArrayList<Elfo> resultado = exercito.getOrdemDoUltimoAtaque();
        assertTrue(resultado.isEmpty());
    }

    @Test
    public void exercitoSoDeUmTipoNãoAtaca() throws NaoPodeAlistarException {
        // Arrange
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.mudarEstrategia(new EstrategiaIntercalada());
        Elfo night1 = new ElfoNoturno("Noturno 1");
        Elfo night2 = new ElfoNoturno("Elfo Noturno 2");
        exercito.alistar(night1);
        exercito.alistar(night2);
        // Act
        exercito.atacar(new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"), new Dwarf("D3"))));
        // Assert
        ArrayList<Elfo> resultado = exercito.getOrdemDoUltimoAtaque();
        assertTrue(resultado.isEmpty());
    }

    @Test
    public void ataqueComExercitoVazio() throws NaoPodeAlistarException {
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.mudarEstrategia(new EstrategiaIntercalada());
        exercito.atacar(new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"))));
        List<Elfo> ordemAtaque = exercito.getOrdemDoUltimoAtaque();
        assertTrue(ordemAtaque.isEmpty());
    }

    @Test
    public void exercitoIntercaladoComElfoNoturnoMortoDesproporcional() throws NaoPodeAlistarException {
        // Arrange
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.mudarEstrategia(new EstrategiaIntercalada());
        Elfo night1 = new ElfoNoturno("EN1");
        for (int i = 0; i < 90; i++) night1.atirarFlecha(new Dwarf("D1"));
        Elfo night2 = new ElfoNoturno("EN2");
        Elfo green1 = new ElfoVerde("EV1");
        Elfo green2 = new ElfoVerde("EV2");
        exercito.alistar(night1);
        exercito.alistar(night2);
        exercito.alistar(green1);
        exercito.alistar(green2);
        // Act
        exercito.atacar(new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"), new Dwarf("D3"))));
        // Assert
        assertTrue(exercito.getOrdemDoUltimoAtaque().isEmpty());
    }

    @Test
    public void exercitoIntercaladoComElfoNoturnoMortoProporcional() throws NaoPodeAlistarException {
        // Arrange
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.mudarEstrategia(new EstrategiaIntercalada());
        Elfo night1 = new ElfoNoturno("EN1");
        for (int i = 0; i < 90; i++) night1.atirarFlecha(new Dwarf("D1"));
        Elfo night2 = new ElfoNoturno("EN2");
        Elfo night3 = new ElfoNoturno("EN3");
        Elfo green1 = new ElfoVerde("EV1");
        Elfo green2 = new ElfoVerde("EV2");
        exercito.alistar(night1);
        exercito.alistar(night2);
        exercito.alistar(night3);
        exercito.alistar(green1);
        exercito.alistar(green2);
        List<Elfo> esperado = new ArrayList<>(Arrays.asList(green2, night2, green1, night3));
        // Act
        exercito.atacar(new ArrayList<>(Arrays.asList(new Dwarf("D1"), new Dwarf("D2"), new Dwarf("D3"))));
        // Assert
        assertEquals(esperado, exercito.getOrdemDoUltimoAtaque());
    }
}
