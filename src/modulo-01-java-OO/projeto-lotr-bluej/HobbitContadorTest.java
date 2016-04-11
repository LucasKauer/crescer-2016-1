import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import java.util.*;

public class HobbitContadorTest {

    @Test
    public void calcularDiferencaTresParesNormais() {
        ArrayList<ArrayList<Integer>> arrayDePares = new ArrayList<>();
        arrayDePares.add(new ArrayList<>(Arrays.asList(15, 18)));
        arrayDePares.add(new ArrayList<>(Arrays.asList(4, 5)));
        arrayDePares.add(new ArrayList<>(Arrays.asList(12, 60)));

        HobbitContador contador = new HobbitContador();
        assertEquals(840, contador.calcularDiferenca(arrayDePares));
    }

    @Test
    public void calcularDiferencaComZeroEUm() {
        ArrayList<ArrayList<Integer>> arrayDePares = new ArrayList<>();
        arrayDePares.add(new ArrayList<>(Arrays.asList(13, 91)));
        arrayDePares.add(new ArrayList<>(Arrays.asList(0, 0)));
        arrayDePares.add(new ArrayList<>(Arrays.asList(1, 1)));

        HobbitContador contador = new HobbitContador();
        assertEquals(1092, contador.calcularDiferenca(arrayDePares));
    }

    @Test
    public void calcularDiferencaSemDiferenca() {
        ArrayList<ArrayList<Integer>> arrayDePares = new ArrayList<>();
        arrayDePares.add(new ArrayList<>(Arrays.asList(19, 60)));
        arrayDePares.add(new ArrayList<>(Arrays.asList(15, 7)));
        arrayDePares.add(new ArrayList<>(Arrays.asList(4, 5)));

        HobbitContador contador = new HobbitContador();
        assertEquals(0, contador.calcularDiferenca(arrayDePares));
    }

    @Test
    public void calcularDiferencaComParesVazio() {
        ArrayList<ArrayList<Integer>> arrayDePares = new ArrayList<>();
        HobbitContador contador = new HobbitContador();
        assertEquals(0, contador.calcularDiferenca(arrayDePares));
    }

    @Test
    public void obterMaiorMultiploDeTresAte10() {
        assertEquals(9, new HobbitContador().obterMaiorMultiploDeTresAte(10));
    }

    @Test
    public void obterMaiorMultiploDeTresAte12() {
        assertEquals(12, new HobbitContador().obterMaiorMultiploDeTresAte(12));
    }

    @Test
    public void obterMaiorMultiploDeTresAte1() {
        assertEquals(0, new HobbitContador().obterMaiorMultiploDeTresAte(1));
    }

    @Test
    public void obterMaiorMultiploDeTresAte0() {
        assertEquals(0, new HobbitContador().obterMaiorMultiploDeTresAte(0));
    }

    @Test
    public void obterMultiplosDeTresAte10() {
        ArrayList<Integer> multiplosDeTres = new HobbitContador().obterMultiplosDeTresAte(10);
        assertEquals(4, multiplosDeTres.size());
        assertTrue(0 == multiplosDeTres.get(0));
        assertTrue(3 == multiplosDeTres.get(1));
        assertTrue(6 == multiplosDeTres.get(2));
        assertTrue(9 == multiplosDeTres.get(3));
    }

    @Test
    public void obterMultiplosDeTresAte1() {
        ArrayList<Integer> multiplosDeTres = new HobbitContador().obterMultiplosDeTresAte(1);
        assertEquals(1, multiplosDeTres.size());
        assertTrue(0 == multiplosDeTres.get(0));
    }

    @Test
    public void obterMultiplosDeTresAte3() {
        ArrayList<Integer> multiplosDeTres = new HobbitContador().obterMultiplosDeTresAte(3);
        assertEquals(2, multiplosDeTres.size());
        assertTrue(0 == multiplosDeTres.get(0));
        assertTrue(3 == multiplosDeTres.get(1));
    }

}
