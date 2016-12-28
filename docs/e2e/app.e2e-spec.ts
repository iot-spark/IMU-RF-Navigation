import { DocsPage } from './app.po';

describe('docs App', function() {
  let page: DocsPage;

  beforeEach(() => {
    page = new DocsPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
