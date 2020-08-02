import { createMuiTheme } from '@material-ui/core/styles';
// https://material-ui.com/customization/palette/
const appGrey = {
  50: '#fafafa',
  100: '#f5f5f5',
  200: '#eeeeee',
  300: '#e0e0e0',
  400: '#bdbdbd',
  500: '#303030',
  600: '#757575',
  700: '#616161',
  800: '#424242',
  900: '#212121',
  A100: '#d5d5d5',
  A200: '#aaaaaa',
  A400: '#303030',
  A700: '#616161',
  contrastDefaultColor: 'dark'
};

const appPurple = {
  50: '#ede7f6',
  100: '#d1c4e9',
  200: '#b39ddb',
  300: '#9575cd',
  400: '#7e57c2',
  500: '#673ab7',
  600: '#5e35b1',
  700: '#512da8',
  800: '#311b92',
  900: '#0d47a1',
  A100: '#b388ff',
  A200: '#7c4dff',
  A400: '#651fff',
  A700: '#6200ea',
  contrastDefaultColor: 'light',
  light: '#bbdefb'
};

const primaryDark = appPurple[700];
const primaryDarker = appPurple[900];
const secondaryDark = appGrey[700];
const secondaryDarker = appGrey[900];
const light = appGrey[100];
const dark = appGrey[900];
const white = '#FFFFFF';

const theme = createMuiTheme({
  typography: {
    fontFamily: '"Roboto", sans-serif',
    useNextVariants: true
  },
  palette: {
    type: 'light',
    primary: appPurple,
    secondary: appPurple
  },
  primary: {
    main: white,
    light: white,
    dark: primaryDark,
    contrastText: secondaryDarker,
    text: dark
  },
  secondary: {
    main: white,
    light: white,
    dark: secondaryDark,
    text: dark,
    contrastText: dark
  },
  light: {
    background: {
      default: white,
      paper: white,
      appBar: white,
      contentFrame: '#eeeeee',
      chip: light
    }
  },
  dark: {
    background: {
      default: '#fafafa',
      paper: white,
      appBar: dark,
      contentFrame: '#eeeeee',
      chip: light
    }
  },
  overrides: {
    MuiAppBar: {
      colorPrimary: {
        color: dark,
        backgroundColor: white
      }
    },
    MuiPaper: {
      root: {
        backgroundColor: white
      }
    },
    MuiCard: {
      root: {
        color: dark,
        backgroundColor: white
      }
    },
    MuiDialog: {
      paper: {
        margin: '0'
      }
    },
    MuiInput: {
      input: {
        padding: 10
      }
    },
    MuiButton: {
      textPrimary: {
        background: primaryDark,
        color: light,
        borderRadius: 0,
        border: 0,
        height: 40,
        padding: '0 15px',
        boxShadow: 'none',
        '&:hover': {
          backgroundColor: primaryDarker,
          color: light
        }
      },
      textSecondary: {
        background: secondaryDark,
        color: light,
        borderRadius: 0,
        border: 0,
        height: 40,
        padding: '0 15px',
        boxShadow: 'none',
        '&:hover': {
          backgroundColor: secondaryDarker,
          color: light
        }
      }
    }
  },
  gutters: 0
});

export default theme;
