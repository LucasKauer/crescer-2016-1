import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import java.util.*;

public class ExercitoDeElfosTest {

    @After
    public void tearDown() {
        System.gc();
    }

    @Test
    public void alistarElfoBaseNãoAlista() {
        // Arrange
        Elfo elfo = new Elfo("Legolas");
        HashMap<String, Elfo> exercitoEsperado = new HashMap<>();
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        // Act
        try {
            exercito.alistar(elfo);
            // Assert
            HashMap<String, Elfo> obtido = exercito.getExercito();
            assertEquals(exercitoEsperado, obtido);
        } catch (NaoPodeAlistarException npae) {
            System.out.println(npae);
        }
    }

    @Test(expected=NaoPodeAlistarException.class)
    public void alistarDoisElfosBaseNãoAlistaNenhum() throws NaoPodeAlistarException {
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
    public void alistarElfoVerdeAlista() throws NaoPodeAlistarException {
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
    public void alistarElfoNoturnoAlista() throws NaoPodeAlistarException {
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
    public void alistarElfosVerdesENoturnosAlistaTodos() throws NaoPodeAlistarException {
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

    @Test(expected=NaoPodeAlistarException.class)
    public void alistarElfosVerdesENoturnosAlistaTodosMenosBase() throws NaoPodeAlistarException {
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
    public void buscarElfoPorNome() throws NaoPodeAlistarException {
        Elfo elfo = new ElfoNoturno("Night Legolas");
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.alistar(elfo);
        assertEquals(elfo, exercito.buscar("Night Legolas"));
    }

    @Test
    public void buscarElfoPorNomeInexistente() throws NaoPodeAlistarException {
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

    @Test(expected=NaoPodeAlistarException.class)
    public void buscarElfoNomeValidoTipoInvalido() throws NaoPodeAlistarException {
        Elfo elfo = new Elfo("Night Legolas");
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.alistar(elfo);
        assertNull(exercito.buscar("Night Legolas"));
    }

    @Test
    public void buscaElfosVivos() throws NaoPodeAlistarException {
        // Arrange
        ElfoVerde elfoVivo1 = new ElfoVerde("Green 1");
        ElfoNoturno elfoVivo2 = new ElfoNoturno("Aa");
        ElfoVerde elfoVivo3 = new ElfoVerde("BB");
        Elfo elfoMorto1 = criarElfoEMataLo("Dead Elf 1");
        Elfo elfoMorto2 = criarElfoEMataLo("Dead Elf 2");
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.alistar(elfoMorto1);
        exercito.alistar(elfoMorto2);
        exercito.alistar(elfoVivo1);
        exercito.alistar(elfoVivo2);
        exercito.alistar(elfoVivo3);
        // Act
        exercito.agruparPorStatus();
        ArrayList<Elfo> vivos = exercito.buscar(Status.VIVO);
        // Assert
        assertTrue(vivos.contains(elfoVivo1));
        assertTrue(vivos.contains(elfoVivo2));
        assertTrue(vivos.contains(elfoVivo3));
    }

    @Test
    public void buscaElfosMortos() throws NaoPodeAlistarException {
        // Arrange
        ExercitoDeElfos exercito = criarExercitoDeMortosEVivos();
        exercito.agruparPorStatus();
        ArrayList<Elfo> mortos = exercito.buscar(Status.MORTO);
        // Assert
        assertTrue(mortos.contains(exercito.buscar("Dead Elf 1")));
        assertTrue(mortos.contains(exercito.buscar("Dead Elf 2")));
    }

    @Test
    public void buscaElfosInconsciente() throws NaoPodeAlistarException {
        // Arrange
        ExercitoDeElfos exercito = criarExercitoDeMortosEVivos();
        exercito.agruparPorStatus();
        // Act & Assert
        assertNull(exercito.buscar(Status.INCONSCIENTE));
    }

    @Test
    public void agrupaPorStatusDuasVezes() throws NaoPodeAlistarException {
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        Elfo e1 = new ElfoNoturno("Ranger");
        Elfo e2 = new ElfoNoturno("Nopturne");
        Elfo e3 = new ElfoNoturno("Legolas");
        Elfo e4 = criarElfoEMataLo("Night One");
        exercito.alistar(e1);
        exercito.alistar(e2);
        exercito.alistar(e3);
        exercito.alistar(e4);
        exercito.agruparPorStatus();
        ArrayList<Elfo> mortos = exercito.buscar(Status.MORTO);
        ArrayList<Elfo> vivos = exercito.buscar(Status.VIVO);
        assertTrue(mortos.contains(e4));
        assertTrue(vivos.contains(e2));
        e1 = criarElfoEMataLo("Ranger");
        e2 = criarElfoEMataLo("Nopturne");
        exercito.agruparPorStatus();
        mortos = exercito.buscar(Status.MORTO);
        vivos = exercito.buscar(Status.VIVO);
        assertFalse(mortos.contains(e3));
        assertFalse(vivos.contains(e1));
        assertFalse(vivos.contains(e2));
    }

    private ExercitoDeElfos criarExercitoDeMortosEVivos() throws NaoPodeAlistarException {
        ElfoVerde elfoVivo1 = new ElfoVerde("Green 1");
        ElfoNoturno elfoVivo2 = new ElfoNoturno("Aa");
        ElfoVerde elfoVivo3 = new ElfoVerde("BB");
        Elfo elfoMorto1 = criarElfoEMataLo("Dead Elf 1");
        Elfo elfoMorto2 = criarElfoEMataLo("Dead Elf 2");
        ExercitoDeElfos exercito = new ExercitoDeElfos();
        exercito.alistar(elfoMorto1);
        exercito.alistar(elfoMorto2);
        exercito.alistar(elfoVivo1);
        exercito.alistar(elfoVivo2);
        exercito.alistar(elfoVivo3);
        return exercito;
    }

    private Elfo criarElfoEMataLo(String nome) {
        Elfo elfo = new ElfoNoturno(nome);
        // Forçando o hara-kiri
        for (int i = 0; i < 90; i++) {
            elfo.atirarFlecha(new Dwarf("Gimli"));
        }
        return elfo;
    }
}
