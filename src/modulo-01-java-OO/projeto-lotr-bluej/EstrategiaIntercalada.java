import java.util.*;

public class EstrategiaIntercalada implements EstrategiaDeAtaque {
    private ArrayList<Elfo> ordemAtaque = new ArrayList<>();

    public void atacar(ArrayList<Elfo> elfos, ArrayList<Dwarf> dwarves) {

        // garante que não ataca se a lista de elfos é vazia OU o exército não é proporcional (50%-50%)
        if (elfos.isEmpty() || !validarProporcoes(elfos)) {
            return;
        }

        intercalar(elfos);

        for (Elfo elfo : ordemAtaque) {
            for (Dwarf dwarf : dwarves) {
                elfo.atirarFlecha(dwarf);
            }
        }
    }

    public ArrayList<Elfo> getOrdemDoUltimoAtaque() {
        return ordemAtaque;
    }

    private boolean validarProporcoes(ArrayList<Elfo> elfos) {
        int contadorElfosVerdes = 0, contadorElfosNoturnos = 0;

        for (Elfo elfo : elfos) {
            if (elfo.getStatus() == Status.VIVO) {
                if (elfo instanceof ElfoVerde) {
                    contadorElfosVerdes++;
                } else if (elfo instanceof ElfoNoturno) {
                    contadorElfosNoturnos++;
                }
            }
        }

        return contadorElfosVerdes == contadorElfosNoturnos;
    }

    private void intercalar(ArrayList<Elfo> elfos) {     

        Elfo primeiroElfo = elfos.get(0);
        ordemAtaque.add(primeiroElfo);
        Class classeDoUltimoAdicionado = primeiroElfo.getClass();
        elfos.remove(primeiroElfo);

        while (elfos.size() > 0) {
            for (int j = 0; j < elfos.size(); j++) {
                Elfo elfoAtual = elfos.get(j);
                boolean estáIntercalado = elfoAtual.getClass() != classeDoUltimoAdicionado;

                if (estáIntercalado) {
                    ordemAtaque.add(elfoAtual);
                    classeDoUltimoAdicionado = elfoAtual.getClass();
                }
                if (estáIntercalado || elfoAtual.getStatus() == Status.MORTO) {
                    elfos.remove(elfoAtual);
                }
            }
        }
    }
}