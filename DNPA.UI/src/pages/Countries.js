import React, { useEffect, useState, useRef } from 'react';
import { withRouter, Link } from 'react-router-dom';
// material-ui
import Button from '@material-ui/core/Button';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Grid from '@material-ui/core/Grid';
import ArrowLeft from '@material-ui/icons/ArrowLeft';
// services
import DNPAServices from 'services/DNPAServices';
import LocalizationService from 'services/LocalizationService';
// components
import Modal from 'components/Shared/Modal';
import Notifications from 'components/Shared/Notifications';
import LoadingIndicator from 'components/Shared/LoadingIndicator';

function Countries(props) {
  const [locData, setLocData] = useState({});
  const [continentData, setContinentData] = useState({
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
          'error',
          'success',
          'view',
          'close',
          'continents',
          'continentstitle',
          'continentsdescription',
          'countries',
          'countriestitle',
          'search',
          'searchtitle',
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

  const CountriesList = () => {
    if (!isLoadingState && countriesData.length > 0) {
      return countriesData.map((country, index) => (
        <Grid container spacing={0} key={index}>
          <Grid item xs={12} md={3} lg={3} xl={3}>
            <Card className="card white-bg-color bl-1 bb-1">
              <CardContent>
                <h4 className="card-title">{country.countryName}</h4>
              </CardContent>
              <CardActions>
                <Button
                  className="ml-2"
                  color="secondary"
                  href="https://facebook.github.io/react/index.html"
                  target="_blank"
                  rel="noopener"
                >
                  {locData.moreinfo}
                </Button>
              </CardActions>
            </Card>
          </Grid>
        </Grid>
      ));
    } else {
      return <LoadingIndicator display={isLoadingState} size={20} />;
    }
  };

  return (
    <Grid container spacing={0}>
      <Grid item xs={12} className="contentpanel-site">
        <Button className="ml-2" color="secondary" component={Link} to={`/`}>
          <ArrowLeft />
        </Button>
        <h2>{locData.countries}</h2>
        <Grid container spacing={0}>
          <CountriesList />
        </Grid>
      </Grid>
      <Notifications ref={notificationsRef} />
    </Grid>
  );
}

export default withRouter(Countries);
