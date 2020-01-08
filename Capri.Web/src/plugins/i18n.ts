import Vue from 'vue';
import VueI18n from 'vue-i18n';
import NavDeanItems from '../components/navDeanItems.vue';
import CardsView from '../components/importPromoters.vue';

Vue.use(VueI18n);

const messages = {
	'pl': {

		faculty: 'Wydział',
		fieldOfStudy: 'Kierunek',
		IT: 'Informatyka',
		robotics: 'Automatyka i Robotyka',
		bioinformatics: 'Bioinformatyka',
		computerScience: 'Informatyka',
		type: 'Rodzaj',
		fullTime: 'Stacjonarne',
		partTime: 'Niestacjonarne',
		degree: 'Stopień',
		master: 'Magisterskie',
		bachelor: 'Inżynierskie',

		//topBar
		topBar:
		{
			bachelorThesis: 'Lista tematów prac inżynierskich',
			fontSize: 'Czcionka',
		},

		//navPromoterItems
		promoter:
		{
			myProposals: 'Moje tematy',
			listOfThesis: 'Lista tematów',
		},

		//navDeanItems
		dean:
		{
			promoters: 'Promotorzy',
			import: 'Importuj',
			listOfThesis: 'Lista tematów',
		},
		//importPromoters
		import:
		{
			fileInput: 'Wybierz plik',
			set: 'Ustaw',
			bachelor: 'Studia Inżynierskie',
			master: 'Studia Magisterskie',
			expectedTitle: 'Ustaw domyślną wartość oczekiwanej liczby tematów',
			name: 'Imię i nazwisko',
			laboratory: 'Zakład',
			bachelorTopics: 'Liczba Tematów - Inż.',
			masterTopics: 'Liczba Tematów - Mag.',
		},
		//cards
		cards:
		{
			title: 'Tytuł',
			promoter: 'Promotor',
			freeSlots: 'Miejsca',
			filter: 'Filtruj'
		}
	},
	'en': {
		//navStudentItems
		faculty: 'Faculty',
		fieldOfStudy: 'Field of study',
		IT: 'IT',
		robotics: 'Robotics',
		bioinformatics: 'Bioinformatics',
		computerScience: 'Computer Science',
		type: 'Type',
		fullTime: 'Full time',
		partTime: 'Part time',
		degree: 'Degree',
		master: 'Master',
		bachelor: 'Bachelor',

		//topBar
		topBar:
		{
			bachelorThesis: 'List of Bachelor thesis',
			fontSize: 'Font size',
		},

		//navPromoterItems
		promoter:
		{
			myProposals: 'My proposals',
			listOfThesis: 'List of thesis',
		},
		//navDeanItems
		dean:
		{
			promoters: 'Promoters',
			import: 'Import',
			listOfThesis: 'List of thesis',
		},
		//importPromoters
		import:
		{
			fileInput: 'File Input',
			set: 'set',
			bachelor: 'Bachelor',
			master: 'Master',
			expectedTitle: 'Set default expected number of topics',
			name: 'Name',
			laboratory: 'Laboratory',
			bachelorTopics: 'Bachelor topics',
			masterTopics: 'Master topics',
		},

		//cards
		cards:
		{
			title: 'Title',
			promoter: 'Promoter',
			freeSlots: 'Free slots',
			filter: 'Filter'
		}

	}
};

const i18n = new VueI18n({
	locale: 'pl',
	fallbackLocale: 'en',
	messages,
});

export default i18n;