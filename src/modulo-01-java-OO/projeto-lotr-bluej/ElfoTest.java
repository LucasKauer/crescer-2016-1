import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class ElfoTest {
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
        Elfo arwen = new Elfo("Arwen");
        arwen.atirarFlecha(new Dwarf("Soneca"));
        arwen.atirarFlecha(new Dwarf("Dengoso"));
        arwen.atirarFlecha(new Dwarf("Feliz"));
        arwen.atirarFlecha(new Dwarf("Atchim"));
        arwen.atirarFlecha(new Dwarf("Mestre"));
        arwen.atirarFlecha(new Dwarf("Zangado"));
        arwen.atirarFlecha(new Dwarf("Dunga"));
        assertEquals(35, arwen.getFlechas());
        assertEquals(7, arwen.getExperiencia());
    }
}
