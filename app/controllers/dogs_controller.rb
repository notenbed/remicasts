class DogsController < ApplicationController

  # GET /dogs
  def index
  end

  # GET /dogs/new
  def new
    @dog = Dog.new
  end

  # POST /dogs
  def create
    @dog = Dog.new params[:dog]
    if @dog.save
      flash[:notice] = "Successfully added dog #{@dog.name}"
      redirect_to dogs_path
    else
      raise "NOT YET IMPLEMENTED!"
    end
  end

end
