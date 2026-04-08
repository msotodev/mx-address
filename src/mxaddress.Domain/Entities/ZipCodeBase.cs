namespace mxaddress.Domain.Entities
{
	public class ZipCodeBase
	{
		/// <summary>
		/// Código Postal asentamiento
		/// </summary>
		public string Code { get; set; } = string.Empty;

		/// <summary>
		/// Nombre asentamiento
		/// </summary>
		public string SettlementName { get; set; } = string.Empty;

		/// <summary>
		/// Tipo de asentamiento (Catálogo SEPOMEX)
		/// </summary>
		public string SettlementTypeName { get; set; } = string.Empty;

		/// <summary>
		/// Nombre Municipio (INEGI, Marzo 2013)
		/// </summary>
		public string MunicipalityName { get; set; } = string.Empty;

		/// <summary>
		/// Nombre Entidad (INEGI, Marzo 2013)
		/// </summary>
		public string StateName { get; set; } = string.Empty;

		/// <summary>
		/// Nombre Ciudad (Catálogo SEPOMEX)
		/// </summary>
		public string CityName { get; set; } = string.Empty;

		/// <summary>
		/// Código Postal de la Administración Postal que reparte al asentamiento
		/// </summary>
		public string ZipCodeAddress { get; set; } = string.Empty;

		/// <summary>
		/// Clave Entidad (INEGI, Marzo 2013)
		/// </summary>
		public string StateKey { get; set; } = string.Empty;

		/// <summary>
		/// Código Postal de la Administración Postal que reparte al asentamiento
		/// </summary>
		public string OfficeZipCode { get; set; } = string.Empty;

		/// <summary>
		/// Campo Vacio
		/// </summary>
		public string ZipCodeKey { get; set; } = string.Empty;

		/// <summary>
		/// Clave Tipo de asentamiento (Catálogo SEPOMEX)
		/// </summary>
		public string SettlementTypeCode { get; set; } = string.Empty;

		/// <summary>
		/// Clave Municipio (INEGI, Marzo 2013)
		/// </summary>
		public string MunicipalityKey { get; set; } = string.Empty;

		/// <summary>
		/// Identificador único del asentamiento (nivel municipal)
		/// </summary>
		public string UniqueSettlementIdentifier { get; set; } = string.Empty;

		/// <summary>
		/// Zona en la que se ubica el asentamiento (Urbano/Rural)
		/// </summary>
		public string ZoneAddress { get; set; } = string.Empty;

		/// <summary>
		/// Clave Ciudad (Catálogo SEPOMEX)
		/// </summary>
		public string CityKey { get; set; } = string.Empty;
	}
}