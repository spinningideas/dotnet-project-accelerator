import React from 'react';
import Grid from '@material-ui/core/Grid';

function ContinentsList(props) {
	return continentsData.map((continent, index) => (
		<Grid container spacing={0}>
			<Grid item xs={12} md={3} lg={3} xl={3}>
				<Card className="card white-bg-color bl-1 bb-1">
					<CardContent>
						<h4 className="card-title">{continent.continentName}</h4>
					</CardContent>
					<CardActions>
						<Button
							className="ml-2"
							color="secondary"
							href="https://facebook.github.io/react/index.html"
							target="_blank"
							rel="noopener"
						>
							{props.locData.moreinfo}
						</Button>
					</CardActions>
				</Card>
			</Grid>
		</Grid>
	));
} else {
	return <LoadingIndicator display={isLoadingState} size={20} />;
}
}

export default GetStartedMessage;
