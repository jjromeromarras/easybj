using Mecalux.ITSW.EasyBServices.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Mecalux.ITSW.EasyB.Model
{
    public abstract class SignedEntity: CheckEntity
    {
        #region Fields

        public const Char delimiter = '|';

        private const string key = "REWWFSDDFSFSDF654987WER546DSF49WER4ADHRTUREXC32198WQER";

        [CLSCompliant(false), JsonIgnore]
        protected string signature;
        #endregion

        #region Properties

        /// <summary>
        /// Firma de la aplicación
        /// </summary>
        [JsonIgnore]
        public virtual string Signature
        {
            get { return signature; }
            set { signature = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        ///  Genera la firma de un elemento a partir la firma de otro
        /// </summary>
        /// <param name="versionId">Version id de la aplicación</param>
        /// <param name="name">Nombre de la aplicación</param>
        /// <param name="parentElementSignature">Firma del elemento padre</param>
        public void BuildFromParentSignature(Guid versionId, string name, string parentElementSignature)
        {
            KeyValuePair<Guid, string> infoFromParent = GetInfoFromSignature(parentElementSignature);
            if (!string.IsNullOrEmpty(infoFromParent.Value))
                Signature = GenerateExportableElementsSignature(versionId, name, infoFromParent.Value);
        }

        /// <summary>
        /// Encripta el texto que se le pasa como parámetro
        /// </summary>
        /// <param name="text">Texto a encriptar</param>
        /// <returns>Resultado de la encriptación</returns>
        public string EncryptKey(string text)
        {
            byte[] keyArray;
            byte[] arrayToEncript = UTF8Encoding.UTF8.GetBytes(text);

            TripleDESCryptoServiceProvider tdes = null;
            byte[] result;
            MD5CryptoServiceProvider hashmd5 = null;
            try
            {
                //MD5
                hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();

                //3DAS
                tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cTransform = tdes.CreateEncryptor();

                result = cTransform.TransformFinalBlock(arrayToEncript, 0, arrayToEncript.Length);
                tdes.Clear();
            }
            finally
            {
                if (tdes != null)
                    tdes.Dispose();
                if (hashmd5 != null)
                    hashmd5.Dispose();
            }
            //Result
            return Convert.ToBase64String(result, 0, result.Length);
        }

        /// <summary>
        /// Genera la firma de una aplicación
        /// </summary>
        /// <param name="ApplicationversionId">Versión id de la aplicación</param>
        /// <param name="ApplicationName">Nombre de la aplicación</param>
        /// <param name="ApplicationType">Tipo aplicación</param>
        /// <returns>Firma de la aplicación</returns>
        private string GenerateApplicationSignature(Guid ApplicationversionId, string ApplicationName)
        {
            string result = string.Empty;
                if (ApplicationversionId != Guid.Empty && !string.IsNullOrEmpty(ApplicationName))
                    result = EncryptKey(string.Format(CultureInfo.InvariantCulture, "{0}|{1}", ApplicationversionId.ToString(), ApplicationName));
            return result;
        }

        /// <summary>
        /// Obtiene a partir de la firma, el versionid y el nombre del elemento
        /// </summary>
        /// <param name="signature">Firma</param>
        /// <param name="name">Nombre del elemento</param>
        /// para después desencriptar la firma de la aplicación</param>
        /// <returns>Version id y firma de la aplicación</returns>
        public KeyValuePair<Guid, string> GetInfoFromSignature(string signature, string name = null)
        {
            KeyValuePair<Guid, string> pairResult = new KeyValuePair<Guid, string>();
            try
            {
                string result = string.Empty;
                    if (!string.IsNullOrEmpty(signature))
                    {
                        result = DecryptKey(signature);
                        if (!string.IsNullOrEmpty(result))
                        {
                            Guid versionId = new Guid(result.Split(delimiter).FirstOrDefault());
                            string text = GetSubString(result);
                            if (versionId != null && !string.IsNullOrEmpty(text))
                                pairResult = new KeyValuePair<Guid, string>(versionId, text);
                        }
                    }
            }
            catch (Exception ex)
            {
                //log.ErrorException("Exception getting info from signature: ", ex);
            }
            return pairResult;

            /// <summary>
            /// Obtener cadena a partir de un elemento delimitador
            /// </summary>
            /// <param name="text">Texto original</param>
            /// <returns>Texto a partir del delimietador</returns>
            string GetSubString(string text)
            {
                int init = 0;
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    if (text[i] == delimiter)
                    {
                        init = i;
                        break;
                    }
                }
                text = text.Substring(init + 1, text.Length - init - 1);
                return text;
            }

            //Desencriptado de la firma
            string DecryptKey(string text)
            {
                byte[] keyArray;
                byte[] arrayToEncript = Convert.FromBase64String(text);

                TripleDESCryptoServiceProvider tdes = null;
                byte[] resultArray;
                MD5CryptoServiceProvider hashmd5 = null;
                try
                {
                    //MD5
                    hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                    //3DAS
                    tdes = new TripleDESCryptoServiceProvider
                    {
                        Key = keyArray,
                        Mode = CipherMode.ECB,
                        Padding = PaddingMode.PKCS7
                    };
                    ICryptoTransform cTransform = tdes.CreateDecryptor();

                    resultArray = cTransform.TransformFinalBlock(arrayToEncript, 0, arrayToEncript.Length);
                    tdes.Clear();
                }
                finally
                {
                    if (tdes != null)
                        tdes.Dispose();
                    if (hashmd5 != null)
                        hashmd5.Dispose();
                }
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
        }

        public bool IsSignatureOk(SignedEntity entity, Guid applicationVersionId, string applicationSignature, string applicationName, string entityName)
        {
            bool result = true;
            //Si hay superlicencia, no comprobamos las firmas, se  podrá importar cualquier elemento en cualquier aplicación
            if (!Context.IsActivatedAppsStandardDeveloperMode)
            {
                if (!string.IsNullOrEmpty(entity.Signature))
                {
                    //Si el elemento está firmado pueden darse dos casos, que la aplicación lo esté o no.
                    //Si está firmada, desencriptamos la firma del elemento y la de la aplicación contenida en el elmento y comparamos Versionid
                    //Si no está firmada, buscamos su firma y la comparamos con la obtenida del desencriptado del elemento
                    if (string.IsNullOrEmpty(applicationSignature))
                    {
                        KeyValuePair<Guid, string> infoFromSignaturedElement = entity.GetInfoFromSignature(entity.Signature, applicationName);
                        applicationSignature = GenerateApplicationSignature(applicationVersionId, applicationName);
                        if (!string.IsNullOrEmpty(infoFromSignaturedElement.Value) && infoFromSignaturedElement.Value != applicationSignature)
                            result = false;
                    }
                    else
                    {
                        KeyValuePair<Guid, string> infoFromSignaturedElement = entity.GetInfoFromSignature(entity.Signature, entityName);
                        if (infoFromSignaturedElement.Value != null && infoFromSignaturedElement.Value != applicationSignature)
                            result = false;
                    }
                }
                else if (string.IsNullOrEmpty(entity.Signature) && !string.IsNullOrEmpty(applicationSignature))
                {
                    //Si el elemento no está firmado y la aplicación si, no se pueden importar elementos en ella que no estén firmados
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        ///  Genera la firma de una aplicación
        /// </summary>
        /// <param name="versionId">Version id de la aplicación</param>
        /// <param name="name">Nombre de la aplicación</param>
        /// <param name="applicationSignature">Firma de la aplicación, necesaria para el firmado del elemento</param>
        public void SetSignature(Guid versionId, string name, string applicationSignature = null)
        {
            if (string.IsNullOrEmpty(applicationSignature))
                Signature = GenerateApplicationSignature(versionId, name);
            else
                Signature = GenerateExportableElementsSignature(versionId, name, applicationSignature);
        }

        private string GenerateExportableElementsSignature(Guid exportableElementVersionId, string exportableElementName, string exportableElementApplicationSignature)
        {
            string result = string.Empty;
                if (!string.IsNullOrEmpty(exportableElementApplicationSignature) && exportableElementVersionId != Guid.Empty)
                    result = EncryptKey(string.Format(CultureInfo.InvariantCulture, "{0}|{1}", exportableElementVersionId.ToString(), exportableElementApplicationSignature));
            return result;
        }

        #endregion Methods
    }
}
