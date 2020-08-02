import React, { useEffect, useState, useRef } from 'react';
import { withRouter, Link } from 'react-router-dom';
// material-ui
import Button from '@material-ui/core/Button';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Grid from '@material-ui/core/Grid';
import List from '@material-ui/core/List';
import Search from '@material-ui/icons/Search';
import { makeStyles } from '@material-ui/core/styles';
// services
import DNPAServices from 'services/DNPAServices';
import LocalizationService from 'services/LocalizationService';
// components
import Notifications from 'components/Shared/Notifications';
import GetStartedMessage from 'components/Home/GetStartedMessage';
import ContinentsList from 'components/Home/ContinentsList';

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
          'continents',
          'continentstitle',
          'continentsdescription',
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
      const continentsDataLoaded = await dnpaServices.getContinents();
      setContinentsData(continentsDataLoaded);
      setIsLoadingState(false);
    }
    loadContinents();
  }, []);

	const useStyles = makeStyles((theme) => ({
		list: {
			width: '100%',
			maxWidth: 400,
			backgroundColor: theme.palette.background.paper,
		},
	}));

	const classes = useStyles();

    return (
    <Grid container spacing={0}>
      <Grid item xs={12} className="contentpanel-site">
        <h2>{locData.homepagewelcome}</h2>

        <Grid container spacing={0}>
          <Grid item xs={12}>
            <GetStartedMessage locData={locData} displayGetStarted={true} />
          </Grid>
          <Grid item xs={12}>
            <Card className="card white-bg-color bl-1 bb-1">
              <CardActions>
                <Button className="ml-2" color="secondary" component={Link} to={`/search`}>
									<Search /> {locData.search}
                </Button>
              </CardActions>
            </Card>
          </Grid>

          <Grid item xs={12} className="pt-1">
            <Grid container>
              <Grid item xs={12} className="pt-1">
                <Card>
                  <CardContent>
                    <h4 className="card-title">{locData.continents}</h4>
                    <p>{locData.continentsdescription}</p>
                    <List className={classes.list} component="nav" spacing={2}>
                      <ContinentsList dataIsLoading={isLoadingState} continentsData={continentsData} />
                    </List>
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
