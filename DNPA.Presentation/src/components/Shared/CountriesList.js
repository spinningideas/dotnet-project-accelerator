import React, { Fragment } from 'react';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import Divider from '@material-ui/core/Divider';
import LoadingIndicator from 'components/Shared/LoadingIndicator';

const CountriesList = (props) => {
  if (!props.dataIsLoading && props.countriesData.length > 0) {
    return props.countriesData.map((country, index) => (
      <Fragment key={index}>
        <ListItem button>
          <ListItemText primary={country.countryName}></ListItemText>
        </ListItem>
        <Divider component="li" />
      </Fragment>
    ));
  } else {
    return <LoadingIndicator display={props.formIsSubmitting} size={20} />;
  }
};

export default CountriesList;
