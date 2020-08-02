import React, { useEffect, useState } from 'react';
import { withRouter, Link } from 'react-router-dom';
// forms
import { Formik, Form, Field } from 'formik';
import { TextField } from 'formik-material-ui';
// material-ui
import Button from '@material-ui/core/Button';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import CardActions from '@material-ui/core/CardActions';
import Grid from '@material-ui/core/Grid';
import List from '@material-ui/core/List';
import ArrowLeft from '@material-ui/icons/ArrowLeft';
import { makeStyles } from '@material-ui/core/styles';
// services
import DNPAServices from 'services/DNPAServices';
import LocalizationService from 'services/LocalizationService';
// components
import CountriesList from 'components/Shared/CountriesList';

function Search(props) {
  const [locData, setLocData] = useState({});
  const [searchData, setSearchData] = useState({searchTerm:''});
  const [formIsSubmitting, setFormIsSubmitting] = useState(false);
  const [countriesData, setCountriesData] = useState([]);

  const dnpaServices = DNPAServices();
  const localizationService = LocalizationService();

  useEffect(() => {
    async function loadLocalization() {
      const locCode = localizationService.getUserLocale();
      const locDataLoaded = await localizationService.getLocalizedTextSet(
        ['required', 'countries', 'search', 'searchdescription', 'moreinfo'],
        locCode
      );
      setLocData(locDataLoaded);
    }
    loadLocalization();
  }, []);

  const useStyles = makeStyles((theme) => ({
    formField: {
      '& .MuiTextField-root': {
        margin: theme.spacing(1),
        width: 400
      }
    },
    list: {
      width: '100%',
      maxWidth: 400,
      backgroundColor: theme.palette.background.paper
    }
  }));

  const classes = useStyles();

  const searchForCountries = async (searchTerm) => {
    setSearchData({searchTerm:searchTerm});
    const countriesDataLoaded = await dnpaServices.searchCountries(searchTerm);
    setCountriesData(countriesDataLoaded);
    setFormIsSubmitting(false);
  };

  const SearchForm = () => {
    return (
      <Grid container spacing={0}>
        <Grid item xs={12}>
          <Formik
            initialValues={searchData}
            validate={(values) => {
              const errors = {};
              if (!values.searchTerm) {
                errors.name = locData.required;
              }
              return errors;
            }}
            onSubmit={(values) => {
							setFormIsSubmitting(true);
              searchForCountries(values.searchTerm);
            }}
          >
            {({ submitForm }) => (
              <Form>
                <Card>
                  <CardContent>
                    <div className={classes.formField}>
                      <Field
                        component={TextField}
                        name="searchTerm"
                        type="text"
                        value={searchData.searchTerm}
                        label={locData.search}
                        required
                      />
                    </div>
                  </CardContent>
                  <CardActions>
                    <Button className="ml-2" color="secondary" disabled={formIsSubmitting} onClick={submitForm}>
                      {locData.search}
                    </Button>
                  </CardActions>
                </Card>
              </Form>
            )}
          </Formik>
        </Grid>
      </Grid>
    );
  };

  return (
    <Grid container spacing={0}>
      <Grid item xs={12} className="contentpanel-site">
        <Button className="ml-2" color="secondary" component={Link} to={`/`}>
          <ArrowLeft />
        </Button>
        <h2>
          {locData.search} {locData.countries}
        </h2>
        <Grid container spacing={0}>
          <SearchForm />
        </Grid>
        <Grid container spacing={0}>
          <List className={classes.list} component="nav" spacing={2}>
            <CountriesList dataIsLoading={formIsSubmitting} countriesData={countriesData} />
          </List>
        </Grid>
      </Grid>
    </Grid>
  );
}

export default withRouter(Search);
