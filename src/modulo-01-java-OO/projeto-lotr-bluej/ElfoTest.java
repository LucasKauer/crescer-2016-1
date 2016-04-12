import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class ElfoTest {

    @After
    public void gc() {
        System.gc();
    }

    @Test
    public void elfoNasceCom42Flechas() {
        Elfo arwen = new Elfo("Arwen");
        assertEquals(42, arwen.getFlechas());
    }

    @Test
    public void elfoAtiraFlechaEmUmDwarf() {
        Elfo arwen = new Elfo("Arwen");
        arwen.atirarFlecha(new Dwarf("Gimli"));
        assertEquals(41, arwen.getFlechas());
        assertEquals(1, arwen.getExperiencia());
    }

    @Test
    public void elfoAtiraFlechaEmDoisDwarves() {
        Elfo arwen = new Elfo("Arwen");
        arwen.atirarFlecha(new Dwarf("Gimli"));
        arwen.atirarFlecha(new Dwarf("Dunga"));
        assertEquals(40, arwen.getFlechas());
        assertEquals(2, arwen.getExperiencia());
    }

    @Test
    public void elfoAtiraFlechaEmSeteDwarves() {
        // Arrange
        Elfo arwen = new Elfo("Arwen");
        Dwarf d1 = new Dwarf("Soneca");
        Dwarf d2 = new Dwarf("Dengoso");
        Dwarf d3 = new Dwarf("Feliz");
        Dwarf d4 = new Dwarf("Atchim");
        Dwarf d5 = new Dwarf("Mestre");
        Dwarf d6 = new Dwarf("Zangado");
        Dwarf d7 = new Dwarf("Dunga");
        int flechasEsperadas = 35;
        int experienciaEsperada = 7;
        // Act
        arwen.atirarFlecha(d1);
        arwen.atirarFlecha(d2);
        arwen.atirarFlecha(d3);
        arwen.atirarFlecha(d4);
        arwen.atirarFlecha(d5);
        arwen.atirarFlecha(d6);
        arwen.atirarFlecha(d7);
        // Assert
        assertEquals(flechasEsperadas, arwen.getFlechas());
        assertEquals(experienciaEsperada, arwen.getExperiencia());
    }

    @Test
    public void elfoComNomeEFlechasInformadasToString() {
        Elfo elfo1 = new Elfo("Acabaram os nomes", 1000);
        String textoEsperado = "Acabaram os nomes possui 1000 flechas e 0 níveis de experiência.";

        assertEquals(textoEsperado, elfo1.toString());
    }

    @Test
    public void elfoComUmaFlechaInformadaToString() {
        Elfo elfo1 = new Elfo("Monoflecha", 1);
        String textoEsperado = "Monoflecha possui 1 flecha e 0 níveis de experiência.";
        assertEquals(textoEsperado, elfo1.toString());
    }

    @Test
    public void elfoComUmDeExperienciaToString() {
        Elfo elfo1 = new Elfo(null);
        elfo1.atirarFlecha(new Dwarf("Gimli"));
        String textoEsperado = "null possui 41 flechas e 1 nível de experiência.";
        assertEquals(textoEsperado, elfo1.toString());
    }

    @Test
    public void elfoNasceVivo() {
        assertEquals(Status.VIVO, new Elfo("Celeborn").getStatus());
    }

    @Test
    public void elfoNasceCom100DeVida() {
        assertEquals(100, new Elfo("Celeborn").getVida(), 0.0);
    }

    @Test
    public void criarNenhumElfoNaoIncrementaContador() {
        assertEquals(0, Elfo.getNumeroDeObjetos());
    }
    
    @Test
    public void criar1ElfoIncrementaContador() {
        Elfo elfo1 = new Elfo("Legolas 1");
        assertEquals(1, Elfo.getNumeroDeObjetos());
    }
    
    @Test
    public void criar2ElfosIncrementaContador() {
        Elfo elfo1 = new Elfo("Legolas 1");
        Elfo elfo2 = new Elfo("Legolas 2");
        assertEquals(2, Elfo.getNumeroDeObjetos());
    }
    
    @Test
    public void criar3ElfosIncrementaContador() {
        Elfo elfo1 = new Elfo("Legolas 1");
        Elfo elfo2 = new ElfoVerde("Legolas 2");
        Elfo elfo3 = new ElfoNoturno("Legolas 3");
        assertEquals(3, Elfo.getNumeroDeObjetos());
    }
}