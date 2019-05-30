using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helper
{
    public static class Common
    {
        public static int VratiErrorCodeZaHttpStatus(int httpStatusCode)
        {
            int errorCode;
            switch (httpStatusCode)
            {
                case 401:
                    errorCode = (int)Enums.ErrorCodes.Authorization;
                    break;
                case 403:
                    errorCode = (int)Enums.ErrorCodes.Forbidden;
                    break;
                case 404:
                    errorCode = (int)Enums.ErrorCodes.NotFound;
                    break;
                case 500:
                    errorCode = (int)Enums.ErrorCodes.InternalServerError;
                    break;
                case 502:
                    errorCode = (int)Enums.ErrorCodes.BadGateway;
                    break;
                case 503:
                    errorCode = (int)Enums.ErrorCodes.ServiceUnavailable;
                    break;
                default:
                    errorCode = (int)Enums.ErrorCodes.Other;
                    break;
            }
            return errorCode;
        }

        public static string VratiErrorMessageZaErrorCode(int errorCode)
        {
            string errorMessage;
            switch (errorCode)
            {
                case 1:
                    errorMessage = "Korisnik nema potrebne dozvole da pristupi stranici.";
                    break;
                case 2:
                    errorMessage = "Korisnik nema potrebne dozvole da pristupi stranici.";
                    break;
                case 3:
                    errorMessage = "Korisnik je prijavljen, ali nema potrebne dozvole za resurs.";
                    break;
                case 4:
                    errorMessage = "Tražena stranica ne postoji ili nije dostupna.";
                    break;
                case 5:
                    errorMessage = "Došlo je do greške prilikom procesiranja Vašeg zahteva. Molimo Vas kontaktirajte sistem administratora.";
                    break;
                case 6:
                    errorMessage = "Server koji se ponaša kao proksi server primio je nevažeći odgovor od nadređenog servera.";
                    break;
                case 7:
                    errorMessage = "Server je trenutno nedostupan.";
                    break;
                case 9:
                    errorMessage = "Podaci iz akitvnog direktorijuma trenutno nisu dostupni. Molimo Vas ugasite browser i pokrenite aplikaciju ponovo.";
                    break;
                default:
                    errorMessage = "Došlo je do greške prilikom procesiranja Vašeg zahteva. Molimo Vas kontaktirajte sistem administratora.";
                    break;
            }
            return errorMessage;
        }
    }
}
