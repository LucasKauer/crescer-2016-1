import java.util.*;

public class EstrategiaPriorizandoElfosVerdes implements EstrategiaDeAtaque {
    private ArrayList<Elfo> ordemAtaque = new ArrayList<>();

    public void atacar(ArrayList<Elfo> elfos, ArrayList<Dwarf> dwarves) {
        //ordenaComBubbleSort(elfos);
        ordenaComCollectionSort(elfos);

        for (Elfo elfo : elfos) {
            if (elfo.getStatus() == Status.VIVO) {
                ordemAtaque.add(elfo);
                for (Dwarf dwarf : dwarves) {
                    elfo.atirarFlecha(dwarf);
                }
            }
        }
    }

    public ArrayList<Elfo> getOrdemDoUltimoAtaque() {
        return ordemAtaque;
    }

    private void ordenaComCollectionSort(ArrayList<Elfo> elfos) {
        Collections.sort(elfos, new Comparator<Elfo>() {
                public int compare(Elfo elfoAtual, Elfo proximoElfo) {
                    boolean mesmoTipo = elfoAtual.getClass() == proximoElfo.getClass();

                    if (mesmoTipo) {
                        return 0;
                    }

                    return elfoAtual instanceof ElfoVerde && proximoElfo instanceof ElfoNoturno ? -1 : 1;
                }
            });
    }

    private void ordenaComBubbleSort(ArrayList<Elfo> elfos) {

        boolean houverTroca = true;
        while (houverTroca) {
            houverTroca = false;
            for (int i = 0; i < elfos.size() - 1; i++) {

                Elfo elfoAtual = elfos.get(i);
                Elfo elfoProximo = elfos.get(i + 1);

                // só precisa trocar se um elfo noturno vier antes de um elfo verde
                boolean precisaTrocar = elfoAtual instanceof ElfoNoturno && elfoProximo instanceof ElfoVerde;

                if (precisaTrocar) {
                    elfos.set(i, elfoProximo);
                    elfos.set(i + 1, elfoAtual);
                    houverTroca = true;
                }

            }

        }
    }
}