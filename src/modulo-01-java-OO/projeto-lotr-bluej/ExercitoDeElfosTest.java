import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import java.util.*;

public class ExercitoDeElfosTest {
    @Test
    public void alistarElfoBaseNãoAlista() {
        // Arrange
        Elfo elfo = new Elfo("Legolas");
        HashMap<String, Elfo> exercitoEsperado = new HashMap<>();
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        // Act
        exercito.alistar(elfo);
        // Assert
        HashMap<String, Elfo> obtido = exercito.getExercito();
        assertEquals(exercitoEsperado, obtido);
    }

    @Test
    public void alistarDoisElfosBaseNãoAlistaNenhum() {
        // Arrange
        Elfo elfo = new Elfo("Legolas");
        Elfo elfo2 = new Elfo("Arwen");
        HashMap<String, Elfo> exercitoEsperado = new HashMap<>();
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        // Act
        exercito.alistar(elfo);
        exercito.alistar(elfo2);
        // Assert
        HashMap<String, Elfo> obtido = exercito.getExercito();
        assertEquals(exercitoEsperado, obtido);
    }

    @Test
    public void alistarElfoVerdeAlista() {
        // Arrange
        Elfo elfo = new ElfoVerde("Green Legolas");
        HashMap<String, Elfo> exercitoEsperado = new HashMap<>();
        exercitoEsperado.put(elfo.getNome(), elfo);
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        // Act
        exercito.alistar(elfo);
        // Assert
        HashMap<String, Elfo> obtido = exercito.getExercito();
        assertEquals(exercitoEsperado, obtido);
    }

    @Test
    public void alistarElfoNoturnoAlista() {
        // Arrange
        Elfo elfo = new ElfoNoturno("Night Legolas");
        HashMap<String, Elfo> exercitoEsperado = new HashMap<>();
        exercitoEsperado.put(elfo.getNome(), elfo);
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        // Act
        exercito.alistar(elfo);
        // Assert
        HashMap<String, Elfo> obtido = exercito.getExercito();
        assertEquals(exercitoEsperado, obtido);
    }

    @Test
    public void alistarElfosVerdesENoturnosAlistaTodos() {
        // Arrange
        Elfo elfo = new ElfoNoturno("Night Legolas");
        Elfo elfo2 = new ElfoNoturno("Night Legolas 2");
        Elfo elfo3 = new ElfoVerde("Green Legolas");
        HashMap<String, Elfo> exercitoEsperado = new HashMap<>();
        exercitoEsperado.put(elfo.getNome(), elfo);
        exercitoEsperado.put(elfo2.getNome(), elfo2);
        exercitoEsperado.put(elfo3.getNome(), elfo3);
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        // Act
        exercito.alistar(elfo);
        exercito.alistar(elfo2);
        exercito.alistar(elfo3);
        // Assert
        HashMap<String, Elfo> obtido = exercito.getExercito();
        assertEquals(exercitoEsperado, obtido);
    }

    @Test
    public void alistarElfosVerdesENoturnosAlistaTodosMenosBase() {
        // Arrange
        Elfo elfo = new ElfoNoturno("Night Legolas");
        Elfo elfo2 = new ElfoNoturno("Night Legolas 2");
        Elfo elfo3 = new ElfoVerde("Green Legolas");
        Elfo elfoBase = new Elfo("Normal Legolas");
        HashMap<String, Elfo> exercitoEsperado = new HashMap<>();
        exercitoEsperado.put(elfo.getNome(), elfo);
        exercitoEsperado.put(elfo2.getNome(), elfo2);
        exercitoEsperado.put(elfo3.getNome(), elfo3);
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        // Act
        exercito.alistar(elfoBase);
        exercito.alistar(elfo);
        exercito.alistar(elfo2);
        exercito.alistar(elfo3);
        // Assert
        HashMap<String, Elfo> obtido = exercito.getExercito();
        assertEquals(exercitoEsperado, obtido);
    }

    @Test
    public void buscarElfoPorNome() {
        Elfo elfo = new ElfoNoturno("Night Legolas");
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.alistar(elfo);
        assertEquals(elfo, exercito.buscar("Night Legolas"));
    }

    @Test
    public void buscarElfoPorNomeInexistente() {
        Elfo elfo = new ElfoNoturno("Night Legolas");
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.alistar(elfo);
        assertNull(exercito.buscar("Birinight Legolas"));
    }

    @Test
    public void buscarElfoPorNomeInexistenteExercitoVazio() {
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        assertNull(exercito.buscar("Birinight Legolas"));
    }

    @Test
    public void buscarElfoNomeValidoTipoInvalido() {
        Elfo elfo = new Elfo("Night Legolas");
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.alistar(elfo);
        assertNull(exercito.buscar("Night Legolas"));
    }
}
