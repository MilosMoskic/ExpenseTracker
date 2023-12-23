using ExpenseTracker.Kontekst;

namespace UpravljanjeTransakcijama.Infastruktura.PoslovnaPravila
{
    public class PoslovnaPravila : IPoslovnaPravila
    {
        private readonly KlasaKontekst _context;
        public PoslovnaPravila(KlasaKontekst context)
        {
            _context = context;
        }

        public bool ProveriBrojTransakcija()
        {
            if (_context.Transakcija.ToList().Count > 10)
            {
                return false;
            }
            return true;
        }
    }
}
