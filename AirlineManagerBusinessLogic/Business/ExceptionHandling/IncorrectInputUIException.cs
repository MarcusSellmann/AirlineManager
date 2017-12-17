using System;

namespace AirlineManager.Business.ExceptionHandling {
	public class IncorrectInputUIException : Exception {
		#region Attributes
		object m_sender;
		string m_wrongInputDescription;
		string m_correctInputHint;
		#endregion

		#region Properties
		public object Sender {
			get {
				return m_sender;
			}
		}

		public string WrongInputDescription {
			get {
				return m_wrongInputDescription;
            }
		}

		public string CorrectInputHint {
			get {
				return m_correctInputHint;
			}
		}
		#endregion

		public IncorrectInputUIException(object sender, string wrongInputDescription, string correctInputHint)
			: base(wrongInputDescription) {
			m_sender = sender;
			m_wrongInputDescription = wrongInputDescription;
			m_correctInputHint = correctInputHint;
        }

		public IncorrectInputUIException(object sender, string wrongInputDescription, string correctInputHint, Exception inner)
			: base(wrongInputDescription, inner) {
			m_sender = sender;
			m_wrongInputDescription = wrongInputDescription;
			m_correctInputHint = correctInputHint;
		}
}
}
