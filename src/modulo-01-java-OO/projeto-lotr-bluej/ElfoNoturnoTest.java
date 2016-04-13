import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class ElfoNoturnoTest {
    private final double DELTA = 0.0;
    
    @After
    public void tearDown() {
        System.gc();
    }
    
    @Test
    public void quandoatirarFlechaGanha3DeExperiencia() {
        ElfoNoturno elfoNoturno = new ElfoNoturno("Night Legolas");
        elfoNoturno.atirarFlecha(new Dwarf("Joe Doein"));
        assertEquals(3, elfoNoturno.getExperiencia());
    }

    @Test
    public void quandoatirarDuasFlechasGanha6DeExperiencia() {
        ElfoNoturno elfoNoturno = new ElfoNoturno("Night Legolas");
        elfoNoturno.atirarFlecha(new Dwarf("Joe Doein"));
        elfoNoturno.atirarFlecha(new Dwarf("Joe Doein"));
        assertEquals(6, elfoNoturno.getExperiencia());
    }

    @Test
    public void quandoatirarTresFlechasGanha9DeExperiencia() {
        ElfoNoturno elfoNoturno = new ElfoNoturno("Night Legolas");
        elfoNoturno.atirarFlecha(new Dwarf("Joe Doein"));
        elfoNoturno.atirarFlecha(new Dwarf("Joe Doein"));
        elfoNoturno.atirarFlecha(new Dwarf("Joe Doein"));
        assertEquals(9, elfoNoturno.getExperiencia());
    }

    @Test
    public void quandoatirarFlechaPerde5DeVida() {
        ElfoNoturno elfoNoturno = new ElfoNoturno("Night Legolas");
        elfoNoturno.atirarFlecha(new Dwarf("Joe Doein"));
        assertEquals(95, elfoNoturno.getVida(), DELTA); 
    }

    @Test
    public void quandoAtirarDuasFlechasPerde9ponto75DeVida() {
        ElfoNoturno elfoNoturno = new ElfoNoturno("Night Legolas");
        elfoNoturno.atirarFlecha(new Dwarf("Joe Doein"));
        elfoNoturno.atirarFlecha(new Dwarf("Joe Doein"));
        assertEquals(90.25, elfoNoturno.getVida(), DELTA); 
    }

    @Test
    public void quandoAtirarTresFlechasPerde14pontos() {
        ElfoNoturno elfoNoturno = new ElfoNoturno("Night Legolas");
        elfoNoturno.atirarFlecha(new Dwarf("Joe Doein"));
        elfoNoturno.atirarFlecha(new Dwarf("Joe Doein"));
        elfoNoturno.atirarFlecha(new Dwarf("Joe Doein"));
        assertEquals(85.7375, elfoNoturno.getVida(), DELTA); 
    }

    @Test
    public void quandoAtirarMuitasFlechasStatusMorto() {
        ElfoNoturno elfoSuiçida = new ElfoNoturno("Night Legolas");

        for (int i = 0; i < 90; i++)
            elfoSuiçida.atirarFlecha(new Dwarf("Joe Doein"));

        assertEquals(Status.MORTO, elfoSuiçida.getStatus());
    }   
}