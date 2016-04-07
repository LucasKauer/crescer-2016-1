import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class DwarfTest
{
    @Test
    public void criarDwarfComNomeNasceCom110DeVida() {
        String nome = "Gimli";
        Dwarf dwarf = new Dwarf(nome);
        assertEquals(110, dwarf.getVida());
        assertEquals(nome, dwarf.getNome());
    }

    @Test
    public void criarDwarfComNomeVazioNasceCom110DeVida() {
        String nome = "";
        Dwarf dwarf = new Dwarf(nome);
        assertEquals(110, dwarf.getVida());
        assertEquals(nome, dwarf.getNome());
    }

    @Test
    public void criarDwarfComNomeNuloNasceCom110DeVida() {
        String nome = null;
        Dwarf dwarf = new Dwarf(nome);
        assertEquals(110, dwarf.getVida());
        assertEquals(nome, dwarf.getNome());
    }

    @Test
    public void dwarfPerde10() {
        Dwarf d1 = new Dwarf("Balin");
        d1.perderVida();
        assertEquals(100, d1.getVida());
    }

    @Test
    public void dwarfPerde20() {
        Dwarf d1 = new Dwarf("Balin");
        d1.perderVida();
        d1.perderVida();
        assertEquals(90, d1.getVida());
    }

    @Test
    public void dwarfPerde120() {
        Dwarf d1 = new Dwarf("Balin");
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        assertEquals(0, d1.getVida());
        assertEquals(Status.MORTO, d1.getStatus());
    }
    
    @Test
    public void dwarfPerde110() {
        Dwarf d1 = new Dwarf("Balin");
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        assertEquals(0, d1.getVida());
        assertEquals(Status.MORTO, d1.getStatus());
    }
    
    @Test
    public void dwarfPerde130() {
        Dwarf d1 = new Dwarf("Balin");
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        d1.perderVida();
        assertEquals(0, d1.getVida());
        assertEquals(Status.MORTO, d1.getStatus());
    }
    
    @Test
    public void dwarfNasceVivo() {
        Dwarf dwarf = new Dwarf("Balin");
        assertEquals(Status.VIVO, dwarf.getStatus());
    }
}
