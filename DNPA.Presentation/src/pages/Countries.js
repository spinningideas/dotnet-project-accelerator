import React, { useEffect, useState, useRef } from 'react';
import { withRouter, Link } from 'react-router-dom';
// material-ui
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import List from '@material-ui/core/List';
import ArrowLeft from '@material-ui/icons/ArrowLeft';
import { makeStyles } from '@material-ui/core/styles';
// services
import DNPAServices from 'services/DNPAServices';
import LocalizationService from 'services/LocalizationService';
// components
import Notifications from 'components/Shared/Notifications';
import CountriesList from 'components/Shared/CountriesList';

function Countries(props) {
  const [locData, setLocData] = useState({});
  const [continentData] = useState({
    continentCode:
      props.match && props.match.params && props.match.params.continentCode ? props.match.params.continentCode : '',
    continentName: ''
  });
  const [isLoadingState, setIsLoadingState] = useState(false);
  const [countriesData, setCountriesData] = useState([]);
  const dnpaServices = DNPAServices();
  const localizationService = LocalizationService();

  const notificationsRef = useRef(null);

  useEffect(() => {
    async function loadLocalization() {
      const locCode = localizationService.getUserLocale();
      const locDataLoaded = await localizationService.getLocalizedTextSet(
        [
          'continents',
          'continentstitle',
          'continentsdescription',
          'countries',
          'countriestitle',
          'search',
          'searchdescription',
          'moreinfo'
        ],
        locCode
      );
      setLocData(locDataLoaded);
    }
    loadLocalization();
  }, []);

  useEffect(() => {
    async function loadContinents() {
      setIsLoadingState(true);
      const countriesDataLoaded = await dnpaServices.getCountries(continentData.continentCode);
      setCountriesData(countriesDataLoaded);
      setIsLoadingState(false);
    }
    loadContinents();
  }, []);

  const useStyles = makeStyles((theme) => ({
    list: {
      width: '100%',
      maxWidth: 400,
      backgroundColor: theme.palette.background.paper
    }
  }));

  const classes = useStyles();

  return (
    <Grid container spacing={0}>
      <Grid item xs={12} className="contentpanel-site">
        <Button className="ml-2 mb-2" color="secondary" component={Link} to={`/`}>
          <ArrowLeft />
        </Button>
        <h2>{locData.countries}</h2>
        <Grid container spacing={0}>
          <List className={classes.list} component="nav" spacing={2}>
            <CountriesList dataIsLoading={isLoadingState} countriesData={countriesData} />
          </List>
        </Grid>
      </Grid>
      <Notifications ref={notificationsRef} />
    </Grid>
  );
}

export default withRouter(Countries);
