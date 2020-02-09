export default {
    commons: {
        loginViaElogin: 'Zaloguj się przez eLogin',
        tryingToLogin: 'Próbuję się zalogować...',
        dataLoading: 'Wczytywanie danych...',
        itemsPerPage: 'Liczba elem. na stronie',
        importPromoters: 'Importuj',
        exportPromoters: 'Eksportuj',
        create: 'Utwórz',
        update: 'Aktualizuj',
        delete: 'Usuń',
        cancel: 'Anuluj',
        close: 'Zamknij',
        any: 'Dowolny',
        import: 'Importuj',
        export: 'Eksportuj',
        optional: '(opcjonalnie)'
    },
    info: {
        studentsAreNotNecessary: 'Na razie nie trzeba podawać studentów. Można dodać ich później',
    },
    rules: {
        topic: {
            required: 'Tytuł jest wymagany',
            atLeast5Chars: 'Tytuł powinien składać się z co najmniej 5 znaków',
            atMost100Chars: 'Tytuł powinien składać się z co najwyżej 100 znaków'
        },
        description: {
            required: 'Opis jest wymagany',
            atLeast5Chars: 'Opis powinien składać się z co najmniej 5 znaków',
            atMost1000Chars: 'Opis powinien składać się z co najwyżej 1000 znaków'
        },
        outputData: {
            atMost1000Chars: 'Dane wyjściowe powinny składać się z co najwyżej 1000 znaków'
        },
        specialization: {
            atMost50Chars: 'Specjalizacja powinna składać się z co najwyżej 50 znaków'
        },
        maxNumberOfStudents: {
            required: 'Ta wartość jest wymagana',
            atLeast1: 'Maks. liczba studentów powinna być większa lub równa 1',
            atMost4: 'Maks. liczba studentów powinna wynosić co najwyżej 4'
        },
        select: {
            required: 'Musisz wybrać wartość'
        },
        student: {
            idAtLeast1: 'Numer indeksu powinien być większy lub równy 1',
            idOnlyDigits: 'Numer indeksu powinien składać się z samych cyfr'
        },
        expectedBachelors: {
            required: 'Ta wartość jest wymagana',
            nonNegative: 'Wartość powinna być liczbą nieujemną',
            atMost10: 'Wartość powinna wynosić co najwyżej 10'
        },
        expectedMasters: {
            required: 'Ta wartość jest wymagana',
            nonNegative: 'Wartość powinna być liczbą nieujemną',
            atMost10: 'Wartość powinna wynosić co najwyżej 10'
        }
    },
    faculty: {
        faculty: 'Wydział',
        name: 'Nazwa'
    },

    course: {
        course: 'Kierunek',
        name: 'Nazwa'
    },

    institute: {
        institute: 'Instytut',
        name: 'Nazwa'
    },

    level: {
        level: 'Poziom',
        bachelor: 'Studia inżynierskie',
        bachelorShort: 'inż.',
        master: 'Studia magisterskie',
        masterShort: 'mgr.'
    },

    mode: {
        mode: 'Tryb',
        fullTime: 'Stacjonarne',
        partTime: 'Niestacjonarne'
    },

    profile: {
        profile: 'Profil',
        generalAcademic: 'Ogólnoakademicki'
    },

    status: {
        status: 'Status',
        free: 'Wolny',
        taken: 'Zajęty',
        partiallyTaken: 'Częściowo zajęty'
    },

    proposal: {
        proposal: 'Propozycja',
        proposalPlural: 'Propozycje',
        myProposals: 'Moje propozycje',
        topic: 'Temat',
        titlePolish: 'Tytuł (PL)',
        titleEnglish: 'Tytuł (ENG)',
        description: 'Opis',
        outputData: 'Dane wyjściowe',
        maxNumberOfStudents: 'Maks. liczba studentów',
        freeSlots: 'Wolne miejsca',
        specialization: 'Specjalizacja',
        startingDate: 'Data rozpoczęcia',
    },

    promoter: {
        promoter: 'Promotor',
        contact: 'Kontakt',
        promoterPlural: 'Promotorzy',
        titlePrefix: 'Tytuł (prefiks)',
        titlePostfix: 'Tytuł (sufiks)',
        firstName: 'Imię',
        lastName: 'Nazwisko',
        expectedNumberOfBachelorProposals: 'Oczekiwana liczba prac inżynierskich',
        expectedNumberOfMasterProposals: 'Oczekiwana liczba prac magisterskich'
    },

    student: {
        student: 'Student',
        studentPlural: 'Studenci',
        indexNumber: 'Numer indeksu',
        firstName: 'Imię',
        lastName: 'Nazwisko',
        semester: 'Semestr'
    },

    import: {
        importTitle: 'Importuj promotorów',
        importLabel: 'Wybierz plik w formacie json'
    },

    confirm: {
        deleteProposal: 'Czy na pewno chcesz usunąć temat?'
    },

    reaction: {
        success: 'Akcja wykonana pomyślnie.',
        serverError: 'Nie można połączyć się z serwerem.',
        badRequest: 'Wykonano nieprawidłowe zapytanie.',
        unauthorized: 'Aby wykonać tę akcję należy się uwierzytelnić.',
        forbidden: 'Nie masz uprawnień by wykonać tę akcję.',
        notFound: 'Nie można znaleźć danego zasobu.',
        otherError: 'Wystąpił nieznany błąd.'
    }
};