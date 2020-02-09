export default {
    commons: {
        loginViaElogin: 'Log in via eLogin',
        tryingToLogin: 'Trying to log in...',
        dataLoading: 'Loading data...',
        itemsPerPage: 'Items per page',
        importPromoters: 'Import promoters data from a file...',
        exportPromoters: 'Export promoters data to a file...',
        create: 'Create',
        update: 'Update',
        delete: 'Delete',
        cancel: 'Cancel',
        close: 'Close',
        any: 'Any',
        import: 'Import',
        export: 'Export',
        optional: '(optional)'
    },
    info: {
        studentsAreNotNecessary: 'Students are not necessary for now. You can add them later',
    },
    rules: {
        topic: {
            required: 'Title is required',
            atLeast5Chars: 'Title should contain at least 5 characters',
            atMost100Chars: 'Title should contain at most 100 characters'
        },
        description: {
            required: 'Description is required',
            atLeast5Chars: 'Description should contain at least 5 characters',
            atMost1000Chars: 'Description should contain at most 1000 characters'
        },
        outputData: {
            atMost1000Chars: 'Output data should contain at most 1000 characters'
        },
        specialization: {
            atMost50Chars: 'Specialization should contain at most 50 characters'
        },
        maxNumberOfStudents: {
            required: 'This value is required',
            atLeast1: 'The maximal number of students should be greater or equal to 1',
            atMost4: 'The maximal number of students should be less or equal to 4'
        },
        select: {
            required: 'You must select a value'
        },
        student: {
            idAtLeast1: 'Student ID number should be greater or equal to 1',
            idOnlyDigits: 'Student ID number should contain only digits'
        },
        expectedBachelors: {
            required: 'This value is required',
            nonNegative: 'The value should be a non-negative number',
            atMost10: 'The value should be less or equal to 10'
        },
        expectedMasters: {
            required: 'This value is required',
            nonNegative: 'The value should be a non-negative number',
            atMost10: 'The value should be less or equal to 10'
        }
    },
    faculty: {
        faculty: 'Faculty',
        name: 'Name'
    },

    course: {
        course: 'Field of study',
        name: 'Name'
    },

    institute: {
        institute: 'Institute',
        name: 'Name'
    },

    level: {
        level: 'Level',
        bachelor: 'Bachelor',
        bachelorShort: 'BSc.',
        master: 'Master',
        masterShort: 'MSc.'
    },

    mode: {
        mode: 'Mode',
        fullTime: 'Full-time',
        partTime: 'Part-time'
    },

    profile: {
        profile: 'Profile',
        generalAcademic: 'General academic'
    },

    status: {
        status: 'Status',
        free: 'Free',
        taken: 'Taken',
        partiallyTaken: 'Partially taken'
    },

    proposal: {
        proposal: 'Proposal',
        proposalPlural: 'Proposals',
        myProposals: 'My proposals',
        topic: 'Topic',
        titlePolish: 'Title (PL)',
        titleEnglish: 'Title (ENG)',
        description: 'Description',
        outputData: 'Output data',
        maxNumberOfStudents: 'Max. number of students',
        freeSlots: 'Slots',
        specialization: 'Specialization',
        startingDate: 'Start date',
    },

    promoter: {
        promoter: 'Promoter',
        contact: 'Contact',
        promoterPlural: 'Promoters',
        titlePrefix: 'Title (prefix)',
        titlePostfix: 'Title (suffix)',
        firstName: 'First name',
        lastName: 'Last name',
        expectedNumberOfBachelorProposals: 'Expected number of bachelor proposals',
        expectedNumberOfMasterProposals: 'Expected number of master proposals'
    },

    student: {
        student: 'Student',
        studentPlural: 'Students',
        indexNumber: 'Student ID',
        firstName: 'First name',
        lastName: 'Last name',
        semester: 'Semester'
    },

    import: {
        importTitle: 'Import promoters',
        importLabel: 'Select file in json format'
    },

    confirm: {
        deleteProposal: 'Are you sure to delete proposal?'
    },

    reaction: {
        success: 'Action successful.',
        serverError: 'Cannot connect to the server.',
        badRequest: 'Bad request.',
        unauthorized: 'Action unauthorized.',
        forbidden: 'You do not have permission to perform that action.',
        notFound: 'Cannot find given resource.',
        otherError: 'Unknown error occured.'
    }
};