import React, { useEffect, useState } from 'react';
// material-ui
import Button from '@material-ui/core/Button';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Grid from '@material-ui/core/Grid';
// Services
import LocalizationService from 'services/LocalizationService';

export default function About() {
  const [locData, setLocData] = useState({});

  const localizationService = LocalizationService();

  useEffect(() => {
    async function loadLocalization() {
      const locCode = localizationService.getUserLocale();

      const locDataLoaded = await localizationService.getLocalizedTextSet(
        ['about', 'aboutdescription', 'moreinfo'],
        locCode
      );
      setLocData(locDataLoaded);
    }
    loadLocalization();
  }, []);

  return (
    <Grid container spacing={0}>
      <Grid item xs={12} className="contentpanel-site">
        <Grid container spacing={0}>
          <Grid item xs={12} md={3} lg={3} xl={3}>
            <Card className="card white-bg-color bl-1 bb-1">
              <CardContent>
                <h4 className="card-title">{locData.about}</h4>
                <p className="card-text">{locData.aboutdescription}</p>
              </CardContent>
              <CardActions>
                <Button
                  className="ml-2"
                  color="secondary"
                  href="https://github.com/spinningideas/dotnet-project-accelerator"
                  target="_blank"
                  rel="noopener"
                >
                  {locData.moreinfo}
                </Button>
              </CardActions>
            </Card>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
}
