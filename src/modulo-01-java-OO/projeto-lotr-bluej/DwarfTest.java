import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class DwarfTest {

    private final double DELTA = 0.0;

    @Test
    public void criarDwarfComNomeNasceCom110DeVida() {
        String nome = "Gimli";
        Dwarf dwarf = new Dwarf(nome);
        assertEquals(110, dwarf.getVida(), DELTA);
        assertEquals(nome, dwarf.getNome());
    }

    @Test
    public void criarDwarfComNomeVazioNasceCom110DeVida() {
        String nome = "";
        Dwarf dwarf = new Dwarf(nome);
        assertEquals(110, dwarf.getVida(), DELTA);
        assertEquals(nome, dwarf.getNome());
    }

    @Test
    public void criarDwarfComNomeNuloNasceCom110DeVida() {
        String nome = null;
        Dwarf dwarf = new Dwarf(nome);
        assertEquals(110, dwarf.getVida(), DELTA);
        assertEquals(nome, dwarf.getNome());
    }

    @Test
    public void dwarfPerde10() {
        Dwarf d1 = new Dwarf("Balin");
        d1.perderVida();
        assertEquals(100, d1.getVida(), DELTA);
    }

    @Test
    public void dwarfPerde20() {
        Dwarf d1 = new Dwarf("Balin");
        d1.perderVida();
        d1.perderVida();
        assertEquals(90, d1.getVida(), DELTA);
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
        assertEquals(0, d1.getVida(), DELTA);
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
        assertEquals(0, d1.getVida(), DELTA);
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
        assertEquals(0, d1.getVida(), DELTA);
        assertEquals(Status.MORTO, d1.getStatus());
    }

    @Test
    public void dwarfNasceVivo() {
        Dwarf dwarf = new Dwarf("Balin");
        assertEquals(Status.VIVO, dwarf.getStatus());
    }

    @Test
    public void adicionarItemNoInventario() {
        Dwarf dwarf = new Dwarf("Ben-Hurin");
        Item itemASerAdicionado = new Item(1, "Escudo");
        dwarf.adicionarItem(itemASerAdicionado);

        assertEquals(itemASerAdicionado, dwarf.getInventario().getItens().get(0));
        assertEquals(1, dwarf.getInventario().getItens().size());
    }

    @Test
    public void adicionarDoisItensNoInventario() {
        Dwarf dwarf = new Dwarf("Ben-Hurin");
        Item primeiroItemASerAdicionado = new Item(1, "Escudo");
        Item segundoItemASerAdicionado = new Item(3, "Adagas");
        dwarf.adicionarItem(primeiroItemASerAdicionado);
        dwarf.adicionarItem(segundoItemASerAdicionado);
        assertEquals(primeiroItemASerAdicionado, dwarf.getInventario().getItens().get(0));
        assertEquals(segundoItemASerAdicionado, dwarf.getInventario().getItens().get(1));
        assertEquals(2, dwarf.getInventario().getItens().size());
    }

    @Test
    public void adicionarItemEPerderNoInventario() {
        Dwarf dwarf = new Dwarf("Ben-Hurin");
        Item item = new Item(1, "Escudo");
        dwarf.adicionarItem(item);
        dwarf.perderItem(item);
        assertEquals(0, dwarf.getInventario().getItens().size());
    }

    @Test
    public void criarDwarfSemDataNascimento() {
        Dwarf dwarf = new Dwarf("André Nunin");
        assertEquals(1, dwarf.getDataNascimento().getDia());
        assertEquals(1, dwarf.getDataNascimento().getMes());
        assertEquals(1, dwarf.getDataNascimento().getAno());
    }

    @Test
    public void criarDwarfComDataNascimento() {
        Dwarf dwarf = new Dwarf("André Nunin", new DataTerceiraEra(17, 10, 1945));
        assertEquals(17, dwarf.getDataNascimento().getDia());
        assertEquals(10, dwarf.getDataNascimento().getMes());
        assertEquals(1945, dwarf.getDataNascimento().getAno());
    }

    @Test
    public void criarDwarfComDataNascimentoNula() {
        Dwarf dwarf = new Dwarf("André Nunin", null);
        assertNull(dwarf.getDataNascimento());
    }

    @Test
    public void gerarNumeroAnoBissextoVidaEntre80e90() {
        // Arrange
        Dwarf fabricin = new Dwarf("Fabricin", new DataTerceiraEra(01, 01, 2016));
        fabricin.perderVida();
        fabricin.perderVida();
        fabricin.perderVida();
        // Act
        double resultado = fabricin.getNumeroSorte();
        // Assert
        assertEquals(-3333.0, resultado, 0.00001);
    }

    @Test
    public void gerarNumeroAnoNaoBissextoNomeSeixas() {
        // Arrange
        Dwarf seixas = new Dwarf("Seixas", new DataTerceiraEra(01, 01, 2015));
        // Act
        double resultado = seixas.getNumeroSorte();
        // Assert
        assertEquals(33.0, resultado, 0.00001);
    }

    @Test
    public void gerarNumeroSemEntrarNasCondicoes() {
        // Arrange
        Dwarf balin = new Dwarf("Balin");
        // Act
        double resultado = balin.getNumeroSorte();
        // Assert
        assertEquals(101.0, resultado, 0.00001);
    }

    @Test
    public void dwarfRecebeFlechaComNumeroSorteNegativo() {
        // Arrange
        Dwarf dwarf = new Dwarf("Gimli", new DataTerceiraEra(1,1,2000));
        dwarf.perderVida();
        dwarf.perderVida();
        // Act
        dwarf.perderVida();
        // Assert
        assertEquals(2, dwarf.getExperiencia());
        assertEquals(90, dwarf.getVida(), DELTA);   
    }

    @Test
    public void dwarfRecebeFlechadaComAnoNormalMeireles() {
        Dwarf meireles = new Dwarf("Meireles", new DataTerceiraEra(2, 3, 2015));
        meireles.perderVida();
        assertEquals(0, meireles.getExperiencia());
        assertEquals(110, meireles.getVida(), DELTA);
    }

    @Test
    public void dwarfRecebeFlechadaNormal(){
        Dwarf dwarf = new Dwarf("Carlin");
        dwarf.perderVida();
        assertEquals(100, dwarf.getVida(), DELTA);
        assertEquals(0, dwarf.getExperiencia());
    }

    @Test
    public void dwarfLeprechaunComSorte() {
        Dwarf dwarf = new Dwarf("Pete 'O Murphy", new DataTerceiraEra(1, 1, 2000));
        dwarf.adicionarItem(new Item(5, "Pint de Guinness"));
        dwarf.perderVida();
        dwarf.perderVida();
        dwarf.perderVida();
        dwarf.tentarSorte();
        assertEquals(1005, dwarf.getInventario().getItens().get(0).getQuantidade());
    }

    @Test
    public void dwarfLeprechaunSemSorte() {
        Dwarf dwarf = new Dwarf("Pete 'O Murphy");
        dwarf.adicionarItem(new Item(5, "Pint de Guinness"));
        dwarf.perderVida();
        dwarf.perderVida();
        dwarf.perderVida();
        dwarf.tentarSorte();
        assertEquals(5, dwarf.getInventario().getItens().get(0).getQuantidade());
    }

    @Test
    public void descobrirMenosVidaComDoisIguais() {
        Dwarf d2 = new Dwarf("D2");
        Dwarf menor = Dwarf.descobrirMenosVida(new Dwarf("D1"), d2);
        assertEquals(d2, menor);
    }
    
    @Test
    public void descobrirMenosVidaComOPrimeiroMenor() {
        Dwarf d1 = new Dwarf("D1");
        d1.perderVida();
        Dwarf d2 = new Dwarf("D2");
        assertEquals(d1, Dwarf.descobrirMenosVida(d1, d2));
    }
    
    @Test
    public void descobrirMenosVidaComOSegundoMenor() {
        Dwarf d1 = new Dwarf("D1");
        Dwarf d2 = new Dwarf("D2");
        d2.perderVida();
        assertEquals(d2, Dwarf.descobrirMenosVida(d1, d2));
    }
}
