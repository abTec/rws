export default interface Translator {
  name: string;
  hourlyRate: string;
  status: 'Applicant' | 'Certified' | 'Deleted';
  creditCardNumber: string;
}