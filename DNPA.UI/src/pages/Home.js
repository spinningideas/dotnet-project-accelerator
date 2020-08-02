import React, { useEffect, useState, useRef } from 'react';
import { withRouter, Link } from 'react-router-dom';
// material-ui
import Button from '@material-ui/core/Button';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Grid from '@material-ui/core/Grid';
// services
import DNPAServices from 'services/DNPAServices';
import LocalizationService from 'services/LocalizationService';
// components
import Modal from 'components/Shared/Modal';
import Notifications from 'components/Shared/Notifications';
import LoadingIndicator from 'components/Shared/LoadingIndicator';
import GetStartedMessage from 'components/Home/GetStartedMessage';

function Home() {
  const [locData, setLocData] = useState({});
  const [isLoadingState, setIsLoadingState] = useState(false);
  const [continentsData, setContinentsData] = useState([]);
  const dnpaServices = DNPAServices();
  const localizationService = LocalizationService();

  const notificationsRef = useRef(null);

  useEffect(() => {
    async function loadLocalization() {
      const locCode = localizationService.getUserLocale();
      const locDataLoaded = await localizationService.getLocalizedTextSet(
        [
          'welcome',
          'homepagewelcome',
          'getstartedmessage',
          'error',
          'success',
          'view',
          'close',
          'continents',
          'continentstitle',
          'continentsdescription',
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
      const continentsDataLoaded = await dnpaServices.getContinents();
      setContinentsData(continentsDataLoaded);
      setIsLoadingState(false);
    }
    loadContinents();
  }, []);

  const ContinentsList = () => {
    if (!isLoadingState && continentsData.length > 0) {
      return continentsData.map((continent, index) => (
        <Grid container spacing={0} key={index}>
          <Grid item xs={12} md={3} lg={3} xl={3}>
            <Card className="card white-bg-color bl-1 bb-1">
              <CardContent>
                <h4 className="card-title">{continent.continentName}</h4>
              </CardContent>
              <CardActions>
                <Button
                  className="ml-2"
                  color="secondary"
                  component={Link}
                  to={`/countries/${continent.continentCode}`}
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
        <h2>{locData.homepagewelcome}</h2>

        <Grid container spacing={0}>
          <Grid item xs={12}>
            <GetStartedMessage locData={locData} displayGetStarted={true} />
          </Grid>
          <Grid item xs={12} className="pt-1">
            <Grid container>
              <Grid item xs={12} className="pt-1">
                <Card>
                  <CardContent>
                    <h4 className="card-title">{locData.continents}</h4>
                    <p>{locData.continentsdescription}</p>
                    <ContinentsList />
                  </CardContent>
                </Card>
              </Grid>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
      <Notifications ref={notificationsRef} />
    </Grid>
  );
}

export default withRouter(Home);
